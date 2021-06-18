
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CustomerService } from '../services/customer.service';
import { CustomerModel } from '../models/customer.model';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customerDetail.component.html',
  styleUrls: ['./customerDetail.component.scss']
})
export class CustomerDetailComponent implements OnInit {

  private customerId: number;

  public customer: CustomerModel;

  constructor(
    private route: ActivatedRoute,
    private customerService: CustomerService) {
      this.customerId = route.snapshot.params.id;
    }

  ngOnInit() {
    this.customerService.GetCustomer(this.customerId).subscribe(customer => this.customer = customer);
  }

}
