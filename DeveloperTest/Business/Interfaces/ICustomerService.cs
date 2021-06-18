﻿using DeveloperTest.Models;

namespace DeveloperTest.Business.Interfaces
{
    public interface ICustomerService
    {
        CustomerModel[] GetCustomers();

        CustomerModel GetCustomer(int CustomerId);

        CustomerModel CreateCustomer(BaseCustomerModel model);
    }
}
