"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var home_component_1 = require("./home/home.component");
var user_component_1 = require("./user/user.component");
var sign_in_component_1 = require("./user/sign-in/sign-in.component");
var counter_component_1 = require("./counter/counter.component");
var fetch_data_component_1 = require("./fetch-data/fetch-data.component");
exports.appRoutes = [
    { path: 'counter', component: counter_component_1.CounterComponent },
    { path: 'fetch-data', component: fetch_data_component_1.FetchDataComponent },
    { path: 'home', component: home_component_1.HomeComponent },
    {
        path: 'login', component: user_component_1.UserComponent,
        children: [{ path: '', component: sign_in_component_1.SignInComponent }]
    },
    { path: '', redirectTo: '/login', pathMatch: 'full' }
];
//# sourceMappingURL=routes.js.map