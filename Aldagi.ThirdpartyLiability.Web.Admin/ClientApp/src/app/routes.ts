import { Routes } from '@angular/router'
import { UserComponent } from './user/user.component';
import { SignInComponent } from './user/sign-in/sign-in.component';
import { AppComponent } from './app.component';
import { ClientsComponent } from './clients/clients.component';

export const appRoutes: Routes = [
    { path: 'home', component: AppComponent },
    {
        path: 'login', component: UserComponent,
        children: [{ path: '', component: SignInComponent }]
    },
    { path: '', redirectTo: '/login', pathMatch: 'full' },
    { 
        path: 'clients', 
        component: ClientsComponent 
    }
    

];
