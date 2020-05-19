const NodeMediaServer = require('node-media-server');
 
const config = {
  rtmp: {
    port: 1935,
    chunk_size: 60000,
    gop_cache: true,
    ping: 30,
    ping_timeout: 60
  },
  http: {
    port: 8000,
    allow_origin: '*'
  },
  relay: {
    ffmpeg: 'C:\\ffmpeg\\bin\\ffmpeg.exe',
    tasks: [
      {
        app: 'webcam',
        mode: 'static',
        edge: 'rtsp://admin:admin888@192.168.0.149:554/ISAPI/streaming/channels/101',
        name: 'stream',
        rtsp_transport : 'tcp' //['udp', 'tcp', 'udp_multicast', 'http']
      }
    ]
  }
};
 
var nms = new NodeMediaServer(config)
nms.run();