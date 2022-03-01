const { exec } = require('child_process');
exec('http-server webContador', (err, stdout, stderr) => {
    if (err) {
      // node couldn't execute the command
      return
    }
  });