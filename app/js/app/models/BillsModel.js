class BillsModel {

  constructor() {
    this._bills = [];
    this._billsView = new BillsView(qs('#bills'));
  }

  add(bill) {
    bill.status = this._handleApiStatus(bill.status);
    this._bills.push(bill);
    this._billsView.update(this);
  }

  addMany(bills) {
    bills.forEach(bill => {
      bill.status = this._handleApiStatus(bill.status);
      this._bills.push(bill);
    });
    this._billsView.update(this);
  }

  get bills() {
    return [].concat(this._bills);
  }

  getStatusClass(status) {

    switch (status) {
      case 'PENDENTE':
        return 'bill-pending';
        break;
      case 'PAGA':
        return 'bill-paid';
        break;
        case 'VENCIDA':
        return 'bill-expired';
        break;
      default:
        return 'bill-pending';
        break;

    }
  }

  setPaid(id) {

    let index = 0;
    let bill = {};

    for (let i = 0; i < this._bills.length; i++) {
      if(this._bills[i].id == id) {
        index = i;
        bill = this._bills[i];
      }
    }

    bill.status = "PAGA";
    this._bills[index] = bill;

    this._billsView.update(this);
  }

  _handleApiStatus(status) {
    switch (status) {

      case 0:
        return 'INDEFINIDO';
        break;

      case 1:
        return 'PAGA';
        break;

      case 2:
        return 'PENDENTE';
        break;

      case 3:
        return 'VENCIDA';
        break;

      default:
        return 'INDEFINIDO';
        break;

    }
  }

}
