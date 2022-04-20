import {FundType} from './fund-type'

export interface Fund {
  code: string;
  name: string;
  cnpj: string;
  patrimony: number;
  type:FundType
}
