var req = new XMLHttpRequest();
req.onload = function () {
    addLights(JSON.parse(req.response));
};
req.open('GET', '/lights');
req.send();

function addLights(lights) {
    lights.forEach(function (light) {
        addLight(light.name, function () { turnOn(light.id) }, function () { turnOff(light.id) });
    });
    addLight('alla', function () { turnAllOn() }, function () { turnAllOff() });
};

function addLight(name, onCallback, offCallback) {
    var div = document.createElement('div');

    div.appendChild(createButton('OFF', offCallback));
    div.appendChild(createSpan(name));
    div.appendChild(createButton('ON', onCallback));

    document.getElementById('container').appendChild(div);
};

function createButton(title, eventAction) {
    var button = document.createElement('span');
    button.className = 'button';
    button.textContent = title;
    button.addEventListener('click', eventAction);
    return button;
};

function createSpan(title) {
    var span = document.createElement('span');
    span.className = 'content';
    span.textContent = title;
    return span;
};

function turnOn(id) {
    var onReq = new XMLHttpRequest();
    onReq.open('PUT', '/lights/' + id + '/on');
    onReq.send();
}

function turnOff(id) {
    var offReq = new XMLHttpRequest();
    offReq.open('PUT', '/lights/' + id + '/off');
    offReq.send();
}

function turnAllOn() {
    var allOnReq = new XMLHttpRequest();
    allOnReq.open('PUT', '/lights/on');
    allOnReq.send();
}

function turnAllOff() {
    var allOnReq = new XMLHttpRequest();
    allOnReq.open('PUT', '/lights/off');
    allOnReq.send();
}
