function clicked() {
    var users = [
        { username: 'user1' },
        { username: 'user2' },
        { username: 'user3' }

    ];
    var pass = [
        { password: '1234' },
        { password: '12345' },
        { password: '123456' }
    ];
    var username = document.getElementById('login-username').value;
    var password = document.getElementById('login-password').value;


    for (var i = 0; i < users.length; i++) {
        for (var j = 0; j < pass.length; j++) {
            if (username == users[i].username && password == pass[j].password) {
                window.open('searchpatient.html');
                break;

            }
            else
                alert("Wrong password");
        }

    }
}
