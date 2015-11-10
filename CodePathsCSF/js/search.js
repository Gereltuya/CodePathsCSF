function clicked() {
    var id = document.getElementById('patient-id');
    var passid = "123456";

    if (id.value == passid) {
        window.alert("you are about to view Nancy's profile");

    }
    else {
        window.alert("you do not have patient under this ID")
    }

}