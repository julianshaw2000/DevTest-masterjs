import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CustomerService } from '../services/customer.service';
import { CustomerModel } from '../models/customer.model';


@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  //public customerTypes = CustomerType;
  // public customerTypes = Object.values(CustomerType);

  public customers: CustomerModel[] = [];

  public newcustomer: CustomerModel = {
    customerId: null,
    customerName: null,
    customerType: null
  };


  constructor(
       private customerService: CustomerService

  ) { }

  ngOnInit() {
        this.customerService.GetCustomers().subscribe(customers => this.customers = customers);

  }



  public createCustomer(form: NgForm): void {
    if (form.invalid) {
      alert('form is not valid');
    } else {
      this.newcustomer.customerType =  +this.newcustomer.customerType;


      this.customerService.CreateCustomer(this.newcustomer).then(() => {
        this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
      });
    }
  }

}

