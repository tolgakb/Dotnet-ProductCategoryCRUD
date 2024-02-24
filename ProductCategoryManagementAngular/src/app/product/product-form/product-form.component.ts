import { Component } from '@angular/core';
import { ProductService } from '../../shared/product.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styles: ``
})
export class ProductFormComponent {

  constructor(public service: ProductService, private toastr: ToastrService)
  {

  }


  onSubmit(form:NgForm)
  {
    this.service.formSubmitted = true
    if(form.valid){
      if(this.service.formData.id == 0)
        this.insertRecord(form)
      else
        this.updateRecord(form)
    }
  }

  insertRecord(form: NgForm)
  {
    this.service.postProductDetail()
    .subscribe({
      next: res => {
        this.service.refreshList();
        this.service.resetForm(form);
        this.toastr.success('Product inserted successfully', "Register product")
      },
      error: err => {console.log(err)}
    })
  }  

  updateRecord(form: NgForm)
  {
    this.service.putProductDetail()
    .subscribe({
      next: res => {
        this.service.refreshList();
        this.service.resetForm(form);
        this.toastr.info('Product updated successfully', "Update product")
      },
      error: err => {console.log(err)}
    })
  }

}
