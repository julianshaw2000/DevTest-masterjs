import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { EngineerService } from '../services/engineer.service';
import { JobService } from '../services/job.service';
import { JobModel } from '../models/job.model';
import { CustomerService } from '../services/customer.service';
import { CustomerModel } from '../models/customer.model';

@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.scss']
})
export class JobComponent implements OnInit {

  public engineers: string[] = [];

  public jobs: JobModel[] = [];
  public customers: CustomerModel[] = [];

  public newJob: JobModel = {
    jobId: null,
    customerId: null,
    customerName: null,
    engineer: null,
    when: null
  };

  constructor(
    private engineerService: EngineerService,
    private customerService: CustomerService,
    private jobService: JobService) { }

  ngOnInit() {
    this.engineerService.GetEngineers().subscribe(engineers => this.engineers = engineers);
    this.jobService.GetJobs().subscribe(jobs => this.jobs = jobs);
    this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
  }

  public createJob(form: NgForm): void {
    if (form.invalid) {
      alert('form is not valid');
    } else {
      console.log(this.newJob)
      this.jobService.CreateJob(this.newJob).then(() => {
        this.jobService.GetJobs().subscribe(jobs => this.jobs = jobs);
      });
    }
  }

}
