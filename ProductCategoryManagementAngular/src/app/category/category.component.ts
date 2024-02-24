import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../shared/category.service';
import { Category } from '../shared/category.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styles: ``
})
export class CategoryComponent implements OnInit {

  constructor(public service: CategoryService, private toastr: ToastrService)
  {

  }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: Category)
  {
    this.service.formData = Object.assign({},selectedRecord) ;
  }

  onDelete(id: number )
  {
    if (confirm('Are you sure to delete this record?'))
      this.service.deleteCategoryDetail(id)
      .subscribe({
        next: res => {
          this.service.refreshList();
          this.toastr.error('Category deleted successfully', "Delete category")
        },
        error: err => {console.log(err)}
      })
  }

}

