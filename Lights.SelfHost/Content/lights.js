var req = new XMLHttpRequest();
req.onload = function () {
    displayLights(JSON.parse(req.response));
};
req.open('GET', '/lights');
req.send();

function displayLights(lights) {
    console.log(lights);
};