import { Component } from '@angular/core';
import { CategoryService } from '../../shared/category.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-category-form',
  templateUrl: './category-form.component.html',
  styles: ``
})
export class CategoryFormComponent {

  constructor(public service: CategoryService, private toastr: ToastrService)
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
    this.service.postCategoryDetail()
    .subscribe({
      next: res => {
        this.service.refreshList();
        this.service.resetForm(form);
        this.toastr.success('Category inserted successfully', "Register category")
      },
      error: err => {console.log(err)}
    })
  } 

  updateRecord(form: NgForm)
  {
    this.service.putCategoryDetail()
    .subscribe({
      next: res => {
        this.service.refreshList();
        this.service.resetForm(form);
        this.toastr.info('Category updated successfully', "Update category")
      },
      error: err => {console.log(err)}
    })
  }

}
