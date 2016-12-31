class Http {

  constructor() { }

  get(url) {

    let xhr = new XMLHttpRequest();

    return new Promise((resolve, reject) => {
      xhr.open('GET', url);
      xhr.onreadystatechange = function() {
        if (xhr.readyState == 4) {
          if (xhr.status == 200) {
            resolve(JSON.parse(xhr.responseText));
          } else {
            reject(xhr.responseText);
          }
        }
      }

      xhr.send();
    });
  }

  post(url, data) {
    let xhr = new XMLHttpRequest();

    return new Promise((resolve, reject) => {

      xhr.open('POST', url);
      xhr.setRequestHeader('Content-Type', "application/json;charset=UTF-8");

      xhr.onreadystatechange = function() {
        if (xhr.readyState == 4) {
          if (xhr. status == 200) {
            resolve(xhr.responseText);
          } else {
            reject(xhr.status);
          }
        }
      }

      xhr.send(JSON.stringify(data));

    });
  }

  put(url, data) {

    let xhr = new XMLHttpRequest();

    return new Promise((resolve, reject) => {

      xhr.open('PUT', url);
      xhr.setRequestHeader('Content-Type', "application/json;charset=UTF-8");

      xhr.onreadystatechange = function() {
        if (xhr.readyState == 4) {
          if (xhr.status == 204) {
            resolve(xhr.responseText);
          } else {
            reject(xhr.responseText);
          }
        }
      }

      xhr.send(JSON.stringify(data));

    });
  }
}
