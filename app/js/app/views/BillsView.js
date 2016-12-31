class BillsView {

  constructor(element) {
    this._element = element;
  }

  _template(model) {
    return `

      ${model.bills.map((bill) => {
        return `
        <div class="col-sm-12 col-md-4 col-lg-4">
          <div class="bill-card">
            <span class="bill-status ${model.getStatusClass(bill.status)}">${bill.status}</span>
            <h3 class="bill-title"><strong>${bill.title}</strong></h3>
            <p>Valor: R$ ${bill.amount}</p>
            <p>Vencimento: ${bill.expirationDate}</p>
            <p>Referência: ${bill.reference}</p>
            <p>Obs: ${bill.observations}</p>
            ${bill.status !== 'PAGA' ?
            `<a
                class="btn btn-primary"
                onclick="billsController.setPaid(this, ${bill.id})">
                Marcar como paga
              </a>` :
              ''}
          </div>
         </div>
        `;
      }).join('')}`;
  }

  update(model) {
    this._element.innerHTML = this._template(model);
  }

}
