import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, NG_VALIDATORS } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { SignInComponent } from './user/sign-in/sign-in.component';
import {MatTableModule, MatRadioModule, MatDialogModule, MAT_CHECKBOX_REQUIRED_VALIDATOR, MatButtonModule, MatFormFieldModule, MatInputModule, MatMenuModule, MatIconModule, MatToolbarModule, MatTabsModule, MatListModule, MatDatepickerModule, MatNativeDateModule, MatCardModule, MatPaginatorModule, MatChipRemove, MatChipsModule, MatSelectModule, MatOptionModule} from '@angular/material';
import { ToastrModule} from 'ngx-toastr'
import { UserService } from './shared/services/user.service';

import { appRoutes } from './routes';
import { GeneralService } from './shared/services/general.service';
import { TokenInterceptor } from './shared/interceptors/token.interceptor';
import { ResponseInterceptor } from './shared/interceptors/response.interceptor';
import { AuthService } from './shared/services/auth.service';
import { NavComponent } from './nav/nav.component';
import { ClientsComponent } from './clients/clients.component';
import { ClientDetailsDialogComponent } from './client-details-dialog/client-details-dialog.component';
import { ClientAddDialogComponent } from './client-add-dialog/client-add-dialog.component';
import { ClientService } from './shared/services/client.service';
import { CarService } from './shared/services/car.service';
import { TermService } from './shared/services/term.service';


@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    SignInComponent,
    NavComponent,
    ClientsComponent,
    ClientDetailsDialogComponent,
    ClientAddDialogComponent
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    MatTableModule,
    MatRadioModule,
    MatDialogModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatMenuModule,
    MatIconModule,
    MatToolbarModule,
    MatTabsModule,
    MatListModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatCardModule,
    MatPaginatorModule,
    MatChipsModule,
    MatSelectModule,
    MatOptionModule,
    ToastrModule.forRoot()
  ],
  providers: [
    UserService,
    GeneralService,
    AuthService,
    ClientService,
    CarService,
    TermService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ResponseInterceptor,
      multi: true
    }
  ],
  entryComponents:[
    ClientDetailsDialogComponent,
    ClientAddDialogComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
