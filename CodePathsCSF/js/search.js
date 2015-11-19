function clicked() {
    var id = document.getElementById('patient-id');
    var passid = "123456";

    if (id.value == passid) {

        window.open('patient_index_Nancy.html')
    }

    else {
        alert("No patient under this ID")
    }
}


