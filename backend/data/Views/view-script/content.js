
var mysql = require('mysql');

var con = mysql.createConnection({
    host: "localhost",
    user: "root",
    password: "",
    database: "db_galdar_3d",
    port: "3306",
});



function beforeRender(request, response, done) {
    con.connect(function(err) {
        if (err) throw err;
        con.query('select * from views', function(err, result, fields) {
            if (err) throw err;
            request.data = {
                view: result
            };
            done();
        });
    });
}



