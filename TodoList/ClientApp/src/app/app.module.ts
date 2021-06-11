import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { RouterModule } from '@angular/router'

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpClientModule,
        RouterModule.forRoot([
            { path: 'authentication', loadChildren: () => import('./authentication/authentication.module').then(m => m.AuthenticationModule) },
            { path: 'tasks', loadChildren: () => import('./task-list/task.module').then(m => m.TaskModule) },
            { path: '', redirectTo: '/tasks', pathMatch: 'full' },
            { path: '**', redirectTo: '/404', pathMatch: 'full' }
        ])
    ],
    declarations: [
        AppComponent,
        MenuComponent
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }