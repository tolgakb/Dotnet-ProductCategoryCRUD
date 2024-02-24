import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: []
})
export class AppComponent {
  title = 'ProductCategoryManagementAngular';

  constructor(private router: Router){}

  navigateToProduct(){
    this.router.navigate(['/product']);
  }

  navigateToCategory(){
    this.router.navigate(['category']);
  }

}
