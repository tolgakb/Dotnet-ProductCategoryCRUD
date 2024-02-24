import { Component,OnInit } from '@angular/core';
import { ProductService } from '../shared/product.service';
import { Product } from '../shared/product.model';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styles: ``
})
export class ProductComponent implements OnInit {

  constructor(public service: ProductService, private toastr: ToastrService)
  {

  }
  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: Product)
  {
    this.service.formData = Object.assign({},selectedRecord) ;
  }

  onDelete(id: number )
  {
    if (confirm('Are you sure to delete this record?'))
      this.service.deleteProductDetail(id)
      .subscribe({
        next: res => {
          this.service.refreshList();
          this.toastr.error('Product deleted successfully', "Delete product")
        },
        error: err => {console.log(err)}
      })
  }
}