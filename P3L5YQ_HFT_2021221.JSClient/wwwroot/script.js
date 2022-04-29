let cars = [];
let connection = null;
let cartoupdateId = -1;
getdata();

setupSignalR();

function setupSignalR() {

        connection = new signalR.HubConnectionBuilder()
            .withUrl("http://localhost:24817/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on("CarCreated", (user, message) => {
        getdata();
    });
    connection.on("CarDeleted", (user, message) => {
        getdata();
    });
    connection.on("CarUpdated", (user, message) => {
        getdata();
    });
    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        setTimeout(start, 5000);
    }
};



async function getdata() {
    await fetch('http://localhost:24817/car')
        .then(x => x.json())
        .then(y => {
            cars = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    cars.forEach(car => {
        document.getElementById('resultarea')
            .innerHTML +=
            '<tr><td>' +
            car.carId +
            '</td><td>' + car.type +
            '</td><td>' +
            `<button type="button" onclick="remove(${car.carId})">Remove</button>` +
            `<button type="button" onclick="showupdate(${car.carId})">Update</button>`+
            '</td></tr>';
    })
}

function create() {
    let createtype = document.getElementById('createcartype').value;
    let createtrimid = document.getElementById('createtrimid').value;
    let createengineid = document.getElementById('createengineid').value;
    let createmileage = document.getElementById('createmileage').value;
    let createcolor = document.getElementById('createcolor').value;
    let createmanufdate = document.getElementById('createmanufdate').value;
    let createprice = document.getElementById('createprice').value;
    let createcondition = document.getElementById("createcondi").value;
    if (createcondition === "true")
        createcondition = true;
    else createcondition = false;

    fetch('http://localhost:24817/car', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                type: createtype,
                trimPackageId: createtrimid,
                engineId: createengineid,
                mileage: createmileage,
                condition: createcondition,
                price: createprice,
                chasisColor: 0,
                manufDate: createmanufdate
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        })
}

function remove(id) {
    fetch('http://localhost:24817/car/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function showupdate(id) {
    document.getElementById('CarToUpdate').value = cars
        .find(car => car['carId'] == id)['type'];
    document.getElementById('updateformdiv').style.display = 'flex';
    cartoupdateId = id;
}
function update() {
    document.getElementById('updateformdiv').style.display = 'none';

    let updatetype = document.getElementById('CarToUpdate').value;
    let updatetrimid = document.getElementById('updatetrimid').value;
    let updateengineid = document.getElementById('updateengineid').value;
    let updatemileage = document.getElementById('updatemileage').value;
    let updatecolor = document.getElementById('updatecolors').value;
    let updatemanufdate = document.getElementById('updatemanufdate').value;
    let updateprice = document.getElementById('updateprice').value;
    let updatecondition = document.getElementById('updatecondi').value;
    let id = cartoupdateId;

    if (updatecondition === "true")
        updatecondition = true;
    else updatecondition = false;
    fetch('http://localhost:24817/car/'+id, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                CarId: id,
                Type: updatetype,
                TrimPackageId: updatetrimid,
                EngineId: updateengineid,
                Mileage: updatemileage,
                Price: updateprice,
                Condition: true,
                ChasisColor: 0,
                ManufDate: updatemanufdate
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        })
}