class BillsProvider {

  constructor() {
    this._http = new Http();
    this._bills = [];
  }

  _toApiFormat(bill) {
    return {
      title: bill.title,
      amount: bill.amount,
      expirationDate: bill.expirationDate,
      observations: bill.observations,
      public: bill.public,
      reference: bill.reference,
      status: bill.status
    }
  }

  list() {
    return new Promise((resolve, reject) => {
      this._http.get('/api/Bills')
      .then(bills => resolve(bills))
      .catch(err => reject(err));
    });
  }

  get(id) {
    return new Promise((resolve, reject) => {
      this._http.get(`/api/Bills/${id}`)
      .then(bill => resolve(bill))
      .catch(err => reject(err));
    });
  }

  create(bill) {
      return new Promise((resolve, reject) => {

        this._http.post('/api/Bills', this._toApiFormat(bill))
          .then(response => resolve(response))
          .catch(err => reject(err));
      });
  }

  setPaid(id) {

    return new Promise((resolve, reject) => {
      this.get(id).then(bill => {
        bill.status = 'PAID';
        this._http.put(`/api/Bills/${id}`, this._toApiFormat(bill))
          .then(result => resolve(result))
          .catch(err => reject(err))
      });
    });
  }
}
