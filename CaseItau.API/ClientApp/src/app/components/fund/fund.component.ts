import { Component, Inject, OnInit, NgModule } from '@angular/core';
import { Fund } from 'src/app/models/fund';
import { FundService } from 'src/app/services/fundService';
import { FundType } from 'src/app/models/fund-type';
import { FundTypeService } from 'src/app/services/fundTypeService';
import { NgForm } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-fund',
  templateUrl: './fund.component.html'
})
export class FundComponent implements OnInit {
  fund = {} as Fund;
  fundSearch = {} as Fund;
  fundEdit = {} as Fund;
  funds = [] as Fund[]; 
  types = [] as FundType[];
  type = {} as FundType;

  constructor(private fundService: FundService, private typeService: FundTypeService) {
  }

  ngOnInit() {
    this.getFunds();
    this.getTypes();
  }

  selectChangeHandler(event: any) {
    //update the ui
    this.type.name = event.target.value;
  }

  // defini se um fundo será criado ou atualizado
  createFund(form: NgForm) {
    this.fund.type = this.types.find(type => this.type.name === type.name) as FundType;
    console.log(this.fund)

      this.fundService.createFund(this.fund).subscribe(() => {
        this.cleanForm(form);
      });
  }

  updateFund(form: NgForm) {
    this.fundService.updateFund(this.fundEdit).subscribe(() => {
      this.cleanForm(form);
    });
  }

  // Chama o serviço para obter todos os fundos
  getFunds() {
    this.fundService.getFunds().subscribe((funds: Fund[]) => {
      this.funds = funds;
      this.fundSearch = {} as Fund;
    });
  }

  getTypes() {
    this.typeService.getFundsTypes().subscribe((types: FundType[]) => {
      this.types = types;
    });
  }

  getFundByCode() {
    this.fundService.getFundByCode(this.fundSearch.code).subscribe((fund: Fund) => {
      this.funds = [] as Fund[];
      this.funds.push(fund);
    });
  }
  // deleta um carro
  deleteFund(fund: Fund) {
    this.fundService.deleteFund(fund.code).subscribe(() => {
      this.getFunds();
    });
  }
  updatePatrimony(form: NgForm) {
    this.fundService.updateFundPatrimony(this.fundEdit).subscribe(() => {
      this.cleanForm(form);
    });
  }

  // copia o fundo para ser editado.
  editFund(fund: Fund) {
    this.fundEdit = { ...fund };
  }

  // limpa o formulario
  cleanForm(form: NgForm) {
    this.getFunds();
    form.resetForm();
    this.fund = {} as Fund;
  }
}



