class BillsController {

  constructor() {
    this._billsModel = new BillsModel();
    this._billsProvider = new BillsProvider();

    this._init();
  }

  addBill() {

    let titleInput = qs('#bill-title');
    let amountInput = qs('#bill-amount');
    let exprDateInput = qs('#bill-expiration-date');
    let obsInput = qs('#bill-obs');
    let publicInput = qs('#bill-public');
    let refInput = qs('#bill-reference');

    let bill = new Bill(
      0,
      titleInput.value,
      amountInput.value,
      exprDateInput.value,
      obsInput.value,
      publicInput.checked,
      refInput.value
    );

    console.log(bill);

    this._billsProvider.create(bill)
    .then(id => this._billsProvider.get(id))
    .then(bill => {
        this._billsModel.add(bill);

        titleInput.value = '';
        amountInput.value = '';
        exprDateInput.value = '';
        refInput.value = '';
        obsInput.value = '';
        publicInput.checked = false;
      })
    .catch(err => console.log(err));
  }

  setPaid(trigger, id) {
    this._billsProvider.setPaid(id)
    .then((response) => {
      console.log(response);
      this._billsModel.setPaid(id);
    })
    .catch(err => console.log(err));
  }

  _init() {
    this._billsProvider.list()
      .then(bills => {
        this._billsModel.addMany(bills);
      });
  }
}
