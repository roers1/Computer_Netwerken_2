const {spawn} = require('child_process');
const {exec} = require('child_process');
const kill = require('tree-kill');

const express = require('express');
const app = express();
const server = require('http').createServer(app);
const io = require('socket.io')(server);

let spawnCommand = null;
let cmd = 'ffmpeg';
let argsPreview = [
  '-f', 'dshow',
  '-video_size', '640_360',
  '-i', 'video=HP Wide Vision HD Camera',
  '-pix_fmt', 'yuv420p',
  '-c:v', 'libx264',
  '-preset', 'ultrafast',
  '-tune', 'zerolatency',
  '-f', 'flv', 'rtmp://localhost/live/preview'
];
let args = [
  '-f', 'dshow',
  '-video_size', '640_360',
  '-i', 'video=HP Wide Vision HD Camera',
  '-pix_fmt', 'yuv420p',
  '-c:v', 'libx264',
  '-preset', 'ultrafast',
  '-tune', 'zerolatency',
  '-f', 'flv', 'rtmp://localhost/live/test'
];

app.use(express.static(__dirname + '/public'));

app.get('/', (req, res) => {
  res.sendFile("StartClient.html", {
    root: __dirname
  });
});

app.get('/client', (req, res) => {
  res.sendFile("client.html", {
    root: __dirname
  });
});

io.on('connection', (socket) => {
  socket.on("start-streaming", (data) => {
    spawnCommand = spawn(cmd, args, {
      stdio: "inherit"
    });
    console.log("it started!");
  });

  socket.on("start-preview", (data) => {
    spawnCommand = spawn(cmd, argsPreview, {
      stdio: "inherit"
    });
    console.log("it started!");
  });

  socket.on("stop-preview", (data) => {
    if (spawnCommand != null) {
      kill(spawnCommand.pid);
      console.log('Stopped Streaming!');
    }
  });

  socket.on("stop-streaming", (data) => {
    if (spawnCommand != null) {
      kill(spawnCommand.pid);
      console.log('Stopped Streaming!');
    }
  });
});
console.log("Listening on port: 5000")
server.listen(5000);
