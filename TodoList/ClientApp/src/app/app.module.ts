import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { TaskListComponent } from './task-list/task-list.component';
import { RouterModule } from '@angular/router'

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpClientModule,
        RouterModule.forRoot([
            { path: 'company', loadChildren: () => import('./company/company.module').then(m => m.CompanyModule) },
            { path: 'authentication', loadChildren: () => import('./authentication/authentication.module').then(m => m.AuthenticationModule) },
            { path: '**', redirectTo: '/404', pathMatch: 'full' }
        ])
    ],
    declarations: [
        AppComponent,
        MenuComponent,
        TaskListComponent
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }