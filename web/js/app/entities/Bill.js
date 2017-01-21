class Bill {

  constructor(id, title, amount, expirationDate, obs, isPublic, reference) {

    this._title = title;
    this._amount = amount;
    this._expirationDate = expirationDate;
    this._observations = obs;
    this._status = 'PENDENTE';
    this._id = id;
    this._isPublic = isPublic;
    this._reference = reference;
  }

  get title() {
    return this._title;
  }

  get amount() {
    return this._amount;
  }

  get expirationDate() {
    return this._expirationDate;
  }

  get observations() {
    return this._observations;
  }

  get status() {
    return this._status;
  }

  set status(value) {
    this._status = value;
  }

  get id() {
    return this._id;
  }

  get public() {
    return this._isPublic;
  }

  get reference() {
    return this._reference;
  }
}
