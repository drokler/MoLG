import { Component, OnInit } from '@angular/core';
import { ServiceFactoryService } from '../services/service-factory.service';
import { CompanyApi, CompanyDto } from 'src/gen';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.css']
})
export class CompanyListComponent implements OnInit {
  private companyService: CompanyApi;
  public companies: CompanyDto[] = [];

  constructor(private readonly serviceFactory: ServiceFactoryService){
    this.companyService = serviceFactory.activate(CompanyApi);
  }
  public async ngOnInit(): Promise<void>  {
    await this.updateList();
  }

  public async updateList(): Promise<void> {
    this.companies = await this.companyService.companyGet();
  }

  public async newCompany(): Promise<void> {
    const result = await this.companyService.companyPut();
    await this.updateList();

  }
}


