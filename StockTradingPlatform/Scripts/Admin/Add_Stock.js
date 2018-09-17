var flag1 = true, flag2 = true, flag3 = true;
function validateName() {
    var regex = /^[a-zA-Z ]{2,30}$/;
    var ob1 = document.getElementById("stockName");
    var x = document.getElementById("stockName").value;
    if (!regex.test(x)) {
        ob1.style.backgroundColor = "#ffc2b3";

    } else {
        ob1.style.backgroundColor = "";

    }
}

function validateStockPrice() {
    var ob1 = document.getElementById("currentPrice");
    var x = document.getElementById("currentPrice").value;
    if (x == "") {
        ob1.style.backgroundColor = "#ffc2b3";

    } else {
        ob1.style.backgroundColor = "";

    }
}

function validateQuantity() {
    var ob1 = document.getElementById("quantity");
    var x = document.getElementById("quantity").value;
    if (x == "") {
        ob1.style.backgroundColor = "#ffc2b3";


    } else {
        ob1.style.backgroundColor = "";

    }
}