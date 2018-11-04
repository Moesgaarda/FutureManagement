'use strict';

customElements.define('compodoc-menu', class extends HTMLElement {
    constructor() {
        super();
        this.isNormalMode = this.getAttribute('mode') === 'normal';
    }

    connectedCallback() {
        this.render(this.isNormalMode);
    }

    render(isNormalMode) {
        let tp = lithtml.html(`<nav>
    <ul class="list">
        <li class="title">
            <a href="index.html" data-type="index-link">@coreui/coreui-free-angular-admin-template documentation</a>
        </li>
        <li class="divider"></li>
        ${ isNormalMode ? `<div id="book-search-input" role="search">
    <input type="text" placeholder="Type to search">
</div>
` : '' }
        <li class="chapter">
            <a data-type="chapter-link" href="index.html"><span class="icon ion-ios-home"></span>Getting started</a>
            <ul class="links">
                    <li class="link">
                        <a href="index.html" data-type="chapter-link">
                            <span class="icon ion-ios-keypad" ></span>Overview
                        </a>
                    </li>
                    <li class="link">
                        <a href="dependencies.html"
                            data-type="chapter-link">
                            <span class="icon ion-ios-list"></span>Dependencies
                        </a>
                    </li>
            </ul>
        </li>
        <li class="chapter modules">
            <a data-type="chapter-link" href="modules.html">
                <div class="menu-toggler linked" data-toggle="collapse"
                    ${ isNormalMode ? 'data-target="#modules-links"' : 'data-target="#xs-modules-links"' }>
                    <span class="icon ion-ios-archive"></span>
                    <span class="link-name">Modules</span>
                    <span class="icon ion-ios-arrow-down"></span>
                </div>
            </a>
            <ul class="links collapse"
            ${ isNormalMode ? 'id="modules-links"' : 'id="xs-modules-links"' }>
                    <li class="link">
                        <a href="modules/AppModule.html" data-type="entity-link">AppModule</a>
                            <li class="chapter inner">
                                <div class="simple menu-toggler" data-toggle="collapse"
                                    ${ isNormalMode ? 'data-target="#components-links-module-AppModule-c74da7ad146bac7d1135ea92823b93fa"' : 'data-target="#xs-components-links-module-AppModule-c74da7ad146bac7d1135ea92823b93fa"' }>
                                    <span class="icon ion-md-cog"></span>
                                    <span>Components</span>
                                    <span class="icon ion-ios-arrow-down"></span>
                                </div>
                                <ul class="links collapse"
                                    ${ isNormalMode ? 'id="components-links-module-AppModule-c74da7ad146bac7d1135ea92823b93fa"' : 'id="xs-components-links-module-AppModule-c74da7ad146bac7d1135ea92823b93fa"' }>
                                        <li class="link">
                                            <a href="components/AppComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">AppComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/DefaultLayoutComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">DefaultLayoutComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/LoginComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">LoginComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/P404Component.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">P404Component</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/P500Component.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">P500Component</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/RegisterComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">RegisterComponent</a>
                                        </li>
                                </ul>
                            </li>
                            <li class="chapter inner">
                                <div class="simple menu-toggler" data-toggle="collapse"
                                    ${ isNormalMode ? 'data-target="#injectables-links-module-AppModule-c74da7ad146bac7d1135ea92823b93fa"' : 'data-target="#xs-injectables-links-module-AppModule-c74da7ad146bac7d1135ea92823b93fa"' }>
                                    <span class="icon ion-md-arrow-round-down"></span>
                                    <span>Injectables</span>
                                    <span class="icon ion-ios-arrow-down"></span>
                                </div>
                                <ul class="links collapse"
                                    ${ isNormalMode ? 'id="injectables-links-module-AppModule-c74da7ad146bac7d1135ea92823b93fa"' : 'id="xs-injectables-links-module-AppModule-c74da7ad146bac7d1135ea92823b93fa"' }>
                                        <li class="link">
                                            <a href="injectables/AlertifyService.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules"}>AlertifyService</a>
                                        </li>
                                        <li class="link">
                                            <a href="injectables/AuthService.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules"}>AuthService</a>
                                        </li>
                                        <li class="link">
                                            <a href="injectables/CustomerService.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules"}>CustomerService</a>
                                        </li>
                                        <li class="link">
                                            <a href="injectables/EventLogService.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules"}>EventLogService</a>
                                        </li>
                                        <li class="link">
                                            <a href="injectables/FileUploadService.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules"}>FileUploadService</a>
                                        </li>
                                        <li class="link">
                                            <a href="injectables/ItemService.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules"}>ItemService</a>
                                        </li>
                                        <li class="link">
                                            <a href="injectables/ItemTemplateService.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules"}>ItemTemplateService</a>
                                        </li>
                                        <li class="link">
                                            <a href="injectables/OrderService.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules"}>OrderService</a>
                                        </li>
                                        <li class="link">
                                            <a href="injectables/UserService.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules"}>UserService</a>
                                        </li>
                                </ul>
                            </li>
                    </li>
                    <li class="link">
                        <a href="modules/AppRoutingModule.html" data-type="entity-link">AppRoutingModule</a>
                    </li>
                    <li class="link">
                        <a href="modules/BaseModule.html" data-type="entity-link">BaseModule</a>
                            <li class="chapter inner">
                                <div class="simple menu-toggler" data-toggle="collapse"
                                    ${ isNormalMode ? 'data-target="#components-links-module-BaseModule-4a781dbb5db83b31d3fe46af97446d9b"' : 'data-target="#xs-components-links-module-BaseModule-4a781dbb5db83b31d3fe46af97446d9b"' }>
                                    <span class="icon ion-md-cog"></span>
                                    <span>Components</span>
                                    <span class="icon ion-ios-arrow-down"></span>
                                </div>
                                <ul class="links collapse"
                                    ${ isNormalMode ? 'id="components-links-module-BaseModule-4a781dbb5db83b31d3fe46af97446d9b"' : 'id="xs-components-links-module-BaseModule-4a781dbb5db83b31d3fe46af97446d9b"' }>
                                        <li class="link">
                                            <a href="components/CardsComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">CardsComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/CarouselsComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">CarouselsComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/CollapsesComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">CollapsesComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/FormsComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">FormsComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/PaginationsComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">PaginationsComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/PopoversComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">PopoversComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/ProgressComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">ProgressComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/SwitchesComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">SwitchesComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/TablesComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">TablesComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/TabsComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">TabsComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/TooltipsComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">TooltipsComponent</a>
                                        </li>
                                </ul>
                            </li>
                    </li>
                    <li class="link">
                        <a href="modules/BaseRoutingModule.html" data-type="entity-link">BaseRoutingModule</a>
                    </li>
                    <li class="link">
                        <a href="modules/ButtonsModule.html" data-type="entity-link">ButtonsModule</a>
                            <li class="chapter inner">
                                <div class="simple menu-toggler" data-toggle="collapse"
                                    ${ isNormalMode ? 'data-target="#components-links-module-ButtonsModule-b9503ac6673a3348d9ebfd5167a4a8e6"' : 'data-target="#xs-components-links-module-ButtonsModule-b9503ac6673a3348d9ebfd5167a4a8e6"' }>
                                    <span class="icon ion-md-cog"></span>
                                    <span>Components</span>
                                    <span class="icon ion-ios-arrow-down"></span>
                                </div>
                                <ul class="links collapse"
                                    ${ isNormalMode ? 'id="components-links-module-ButtonsModule-b9503ac6673a3348d9ebfd5167a4a8e6"' : 'id="xs-components-links-module-ButtonsModule-b9503ac6673a3348d9ebfd5167a4a8e6"' }>
                                        <li class="link">
                                            <a href="components/BrandButtonsComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">BrandButtonsComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/ButtonsComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">ButtonsComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/DropdownsComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">DropdownsComponent</a>
                                        </li>
                                </ul>
                            </li>
                    </li>
                    <li class="link">
                        <a href="modules/ButtonsRoutingModule.html" data-type="entity-link">ButtonsRoutingModule</a>
                    </li>
                    <li class="link">
                        <a href="modules/ChartJSModule.html" data-type="entity-link">ChartJSModule</a>
                            <li class="chapter inner">
                                <div class="simple menu-toggler" data-toggle="collapse"
                                    ${ isNormalMode ? 'data-target="#components-links-module-ChartJSModule-fa6c21bade2f543f2d583574f44410f0"' : 'data-target="#xs-components-links-module-ChartJSModule-fa6c21bade2f543f2d583574f44410f0"' }>
                                    <span class="icon ion-md-cog"></span>
                                    <span>Components</span>
                                    <span class="icon ion-ios-arrow-down"></span>
                                </div>
                                <ul class="links collapse"
                                    ${ isNormalMode ? 'id="components-links-module-ChartJSModule-fa6c21bade2f543f2d583574f44410f0"' : 'id="xs-components-links-module-ChartJSModule-fa6c21bade2f543f2d583574f44410f0"' }>
                                        <li class="link">
                                            <a href="components/ChartJSComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">ChartJSComponent</a>
                                        </li>
                                </ul>
                            </li>
                    </li>
                    <li class="link">
                        <a href="modules/ChartJSRoutingModule.html" data-type="entity-link">ChartJSRoutingModule</a>
                    </li>
                    <li class="link">
                        <a href="modules/CustomersModule.html" data-type="entity-link">CustomersModule</a>
                            <li class="chapter inner">
                                <div class="simple menu-toggler" data-toggle="collapse"
                                    ${ isNormalMode ? 'data-target="#components-links-module-CustomersModule-cd3a184fa809d9fe50f5945078ad1b51"' : 'data-target="#xs-components-links-module-CustomersModule-cd3a184fa809d9fe50f5945078ad1b51"' }>
                                    <span class="icon ion-md-cog"></span>
                                    <span>Components</span>
                                    <span class="icon ion-ios-arrow-down"></span>
                                </div>
                                <ul class="links collapse"
                                    ${ isNormalMode ? 'id="components-links-module-CustomersModule-cd3a184fa809d9fe50f5945078ad1b51"' : 'id="xs-components-links-module-CustomersModule-cd3a184fa809d9fe50f5945078ad1b51"' }>
                                        <li class="link">
                                            <a href="components/DetailsCustomerComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">DetailsCustomerComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/NewCustomerComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">NewCustomerComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/ViewCustomersComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">ViewCustomersComponent</a>
                                        </li>
                                </ul>
                            </li>
                    </li>
                    <li class="link">
                        <a href="modules/CustomersRoutingModule.html" data-type="entity-link">CustomersRoutingModule</a>
                    </li>
                    <li class="link">
                        <a href="modules/DashboardModule.html" data-type="entity-link">DashboardModule</a>
                            <li class="chapter inner">
                                <div class="simple menu-toggler" data-toggle="collapse"
                                    ${ isNormalMode ? 'data-target="#components-links-module-DashboardModule-1f22c7a8bcae6edc2020531cfa3ff343"' : 'data-target="#xs-components-links-module-DashboardModule-1f22c7a8bcae6edc2020531cfa3ff343"' }>
                                    <span class="icon ion-md-cog"></span>
                                    <span>Components</span>
                                    <span class="icon ion-ios-arrow-down"></span>
                                </div>
                                <ul class="links collapse"
                                    ${ isNormalMode ? 'id="components-links-module-DashboardModule-1f22c7a8bcae6edc2020531cfa3ff343"' : 'id="xs-components-links-module-DashboardModule-1f22c7a8bcae6edc2020531cfa3ff343"' }>
                                        <li class="link">
                                            <a href="components/DashboardComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">DashboardComponent</a>
                                        </li>
                                </ul>
                            </li>
                    </li>
                    <li class="link">
                        <a href="modules/DashboardRoutingModule.html" data-type="entity-link">DashboardRoutingModule</a>
                    </li>
                    <li class="link">
                        <a href="modules/IconsModule.html" data-type="entity-link">IconsModule</a>
                            <li class="chapter inner">
                                <div class="simple menu-toggler" data-toggle="collapse"
                                    ${ isNormalMode ? 'data-target="#components-links-module-IconsModule-56ba6fc9843bf9081dfa633b73930e0a"' : 'data-target="#xs-components-links-module-IconsModule-56ba6fc9843bf9081dfa633b73930e0a"' }>
                                    <span class="icon ion-md-cog"></span>
                                    <span>Components</span>
                                    <span class="icon ion-ios-arrow-down"></span>
                                </div>
                                <ul class="links collapse"
                                    ${ isNormalMode ? 'id="components-links-module-IconsModule-56ba6fc9843bf9081dfa633b73930e0a"' : 'id="xs-components-links-module-IconsModule-56ba6fc9843bf9081dfa633b73930e0a"' }>
                                        <li class="link">
                                            <a href="components/CoreUIIconsComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">CoreUIIconsComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/FlagsComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">FlagsComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/FontAwesomeComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">FontAwesomeComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/SimpleLineIconsComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">SimpleLineIconsComponent</a>
                                        </li>
                                </ul>
                            </li>
                    </li>
                    <li class="link">
                        <a href="modules/IconsRoutingModule.html" data-type="entity-link">IconsRoutingModule</a>
                    </li>
                    <li class="link">
                        <a href="modules/ItemTemplatesModule.html" data-type="entity-link">ItemTemplatesModule</a>
                            <li class="chapter inner">
                                <div class="simple menu-toggler" data-toggle="collapse"
                                    ${ isNormalMode ? 'data-target="#components-links-module-ItemTemplatesModule-dbcc4e4932fff6eca51249a4caa6bf78"' : 'data-target="#xs-components-links-module-ItemTemplatesModule-dbcc4e4932fff6eca51249a4caa6bf78"' }>
                                    <span class="icon ion-md-cog"></span>
                                    <span>Components</span>
                                    <span class="icon ion-ios-arrow-down"></span>
                                </div>
                                <ul class="links collapse"
                                    ${ isNormalMode ? 'id="components-links-module-ItemTemplatesModule-dbcc4e4932fff6eca51249a4caa6bf78"' : 'id="xs-components-links-module-ItemTemplatesModule-dbcc4e4932fff6eca51249a4caa6bf78"' }>
                                        <li class="link">
                                            <a href="components/DetailsItemTemplateComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">DetailsItemTemplateComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/NewItemTemplateComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">NewItemTemplateComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/ViewItemTemplatesComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">ViewItemTemplatesComponent</a>
                                        </li>
                                </ul>
                            </li>
                    </li>
                    <li class="link">
                        <a href="modules/ItemTemplatesRoutingModule.html" data-type="entity-link">ItemTemplatesRoutingModule</a>
                    </li>
                    <li class="link">
                        <a href="modules/ItemsModule.html" data-type="entity-link">ItemsModule</a>
                            <li class="chapter inner">
                                <div class="simple menu-toggler" data-toggle="collapse"
                                    ${ isNormalMode ? 'data-target="#components-links-module-ItemsModule-911e2f2a827d4c42dada6dde31ad7ae2"' : 'data-target="#xs-components-links-module-ItemsModule-911e2f2a827d4c42dada6dde31ad7ae2"' }>
                                    <span class="icon ion-md-cog"></span>
                                    <span>Components</span>
                                    <span class="icon ion-ios-arrow-down"></span>
                                </div>
                                <ul class="links collapse"
                                    ${ isNormalMode ? 'id="components-links-module-ItemsModule-911e2f2a827d4c42dada6dde31ad7ae2"' : 'id="xs-components-links-module-ItemsModule-911e2f2a827d4c42dada6dde31ad7ae2"' }>
                                        <li class="link">
                                            <a href="components/AddItemsComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">AddItemsComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/DetailsItemComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">DetailsItemComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/ViewItemsComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">ViewItemsComponent</a>
                                        </li>
                                </ul>
                            </li>
                    </li>
                    <li class="link">
                        <a href="modules/ItemsRoutingModule.html" data-type="entity-link">ItemsRoutingModule</a>
                    </li>
                    <li class="link">
                        <a href="modules/LogModule.html" data-type="entity-link">LogModule</a>
                            <li class="chapter inner">
                                <div class="simple menu-toggler" data-toggle="collapse"
                                    ${ isNormalMode ? 'data-target="#components-links-module-LogModule-0cc7167a5c8c5cc92c759f0ec07917e9"' : 'data-target="#xs-components-links-module-LogModule-0cc7167a5c8c5cc92c759f0ec07917e9"' }>
                                    <span class="icon ion-md-cog"></span>
                                    <span>Components</span>
                                    <span class="icon ion-ios-arrow-down"></span>
                                </div>
                                <ul class="links collapse"
                                    ${ isNormalMode ? 'id="components-links-module-LogModule-0cc7167a5c8c5cc92c759f0ec07917e9"' : 'id="xs-components-links-module-LogModule-0cc7167a5c8c5cc92c759f0ec07917e9"' }>
                                        <li class="link">
                                            <a href="components/ViewLogComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">ViewLogComponent</a>
                                        </li>
                                </ul>
                            </li>
                    </li>
                    <li class="link">
                        <a href="modules/LogRoutingModule.html" data-type="entity-link">LogRoutingModule</a>
                    </li>
                    <li class="link">
                        <a href="modules/NotificationsModule.html" data-type="entity-link">NotificationsModule</a>
                            <li class="chapter inner">
                                <div class="simple menu-toggler" data-toggle="collapse"
                                    ${ isNormalMode ? 'data-target="#components-links-module-NotificationsModule-46d4e510a7a1842ed3b0b514da6e0c45"' : 'data-target="#xs-components-links-module-NotificationsModule-46d4e510a7a1842ed3b0b514da6e0c45"' }>
                                    <span class="icon ion-md-cog"></span>
                                    <span>Components</span>
                                    <span class="icon ion-ios-arrow-down"></span>
                                </div>
                                <ul class="links collapse"
                                    ${ isNormalMode ? 'id="components-links-module-NotificationsModule-46d4e510a7a1842ed3b0b514da6e0c45"' : 'id="xs-components-links-module-NotificationsModule-46d4e510a7a1842ed3b0b514da6e0c45"' }>
                                        <li class="link">
                                            <a href="components/AlertsComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">AlertsComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/BadgesComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">BadgesComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/ModalsComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">ModalsComponent</a>
                                        </li>
                                </ul>
                            </li>
                    </li>
                    <li class="link">
                        <a href="modules/NotificationsRoutingModule.html" data-type="entity-link">NotificationsRoutingModule</a>
                    </li>
                    <li class="link">
                        <a href="modules/OrdersModule.html" data-type="entity-link">OrdersModule</a>
                            <li class="chapter inner">
                                <div class="simple menu-toggler" data-toggle="collapse"
                                    ${ isNormalMode ? 'data-target="#components-links-module-OrdersModule-52ef006662af1bdde4801b671bf4fe33"' : 'data-target="#xs-components-links-module-OrdersModule-52ef006662af1bdde4801b671bf4fe33"' }>
                                    <span class="icon ion-md-cog"></span>
                                    <span>Components</span>
                                    <span class="icon ion-ios-arrow-down"></span>
                                </div>
                                <ul class="links collapse"
                                    ${ isNormalMode ? 'id="components-links-module-OrdersModule-52ef006662af1bdde4801b671bf4fe33"' : 'id="xs-components-links-module-OrdersModule-52ef006662af1bdde4801b671bf4fe33"' }>
                                        <li class="link">
                                            <a href="components/DetailsOrderComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">DetailsOrderComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/NewOrderComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">NewOrderComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/ViewOrdersComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">ViewOrdersComponent</a>
                                        </li>
                                </ul>
                            </li>
                    </li>
                    <li class="link">
                        <a href="modules/OrdersRoutingModule.html" data-type="entity-link">OrdersRoutingModule</a>
                    </li>
                    <li class="link">
                        <a href="modules/ProjectsModule.html" data-type="entity-link">ProjectsModule</a>
                            <li class="chapter inner">
                                <div class="simple menu-toggler" data-toggle="collapse"
                                    ${ isNormalMode ? 'data-target="#components-links-module-ProjectsModule-42413a7f814b57a29b38d474f96111ea"' : 'data-target="#xs-components-links-module-ProjectsModule-42413a7f814b57a29b38d474f96111ea"' }>
                                    <span class="icon ion-md-cog"></span>
                                    <span>Components</span>
                                    <span class="icon ion-ios-arrow-down"></span>
                                </div>
                                <ul class="links collapse"
                                    ${ isNormalMode ? 'id="components-links-module-ProjectsModule-42413a7f814b57a29b38d474f96111ea"' : 'id="xs-components-links-module-ProjectsModule-42413a7f814b57a29b38d474f96111ea"' }>
                                        <li class="link">
                                            <a href="components/DetailsProjectComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">DetailsProjectComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/NewProjectComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">NewProjectComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/ViewProjectsComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">ViewProjectsComponent</a>
                                        </li>
                                </ul>
                            </li>
                    </li>
                    <li class="link">
                        <a href="modules/ProjectsRoutingModule.html" data-type="entity-link">ProjectsRoutingModule</a>
                    </li>
                    <li class="link">
                        <a href="modules/ThemeModule.html" data-type="entity-link">ThemeModule</a>
                            <li class="chapter inner">
                                <div class="simple menu-toggler" data-toggle="collapse"
                                    ${ isNormalMode ? 'data-target="#components-links-module-ThemeModule-496e68feeaefb3480f98a45349a15edb"' : 'data-target="#xs-components-links-module-ThemeModule-496e68feeaefb3480f98a45349a15edb"' }>
                                    <span class="icon ion-md-cog"></span>
                                    <span>Components</span>
                                    <span class="icon ion-ios-arrow-down"></span>
                                </div>
                                <ul class="links collapse"
                                    ${ isNormalMode ? 'id="components-links-module-ThemeModule-496e68feeaefb3480f98a45349a15edb"' : 'id="xs-components-links-module-ThemeModule-496e68feeaefb3480f98a45349a15edb"' }>
                                        <li class="link">
                                            <a href="components/ColorsComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">ColorsComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/TypographyComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">TypographyComponent</a>
                                        </li>
                                </ul>
                            </li>
                    </li>
                    <li class="link">
                        <a href="modules/ThemeRoutingModule.html" data-type="entity-link">ThemeRoutingModule</a>
                    </li>
                    <li class="link">
                        <a href="modules/UsersModule.html" data-type="entity-link">UsersModule</a>
                            <li class="chapter inner">
                                <div class="simple menu-toggler" data-toggle="collapse"
                                    ${ isNormalMode ? 'data-target="#components-links-module-UsersModule-2b4c607cb060c764aad6e57ec190f95c"' : 'data-target="#xs-components-links-module-UsersModule-2b4c607cb060c764aad6e57ec190f95c"' }>
                                    <span class="icon ion-md-cog"></span>
                                    <span>Components</span>
                                    <span class="icon ion-ios-arrow-down"></span>
                                </div>
                                <ul class="links collapse"
                                    ${ isNormalMode ? 'id="components-links-module-UsersModule-2b4c607cb060c764aad6e57ec190f95c"' : 'id="xs-components-links-module-UsersModule-2b4c607cb060c764aad6e57ec190f95c"' }>
                                        <li class="link">
                                            <a href="components/DetailsUserComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">DetailsUserComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/EditUserComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">EditUserComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/NewUserComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">NewUserComponent</a>
                                        </li>
                                        <li class="link">
                                            <a href="components/ViewUsersComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">ViewUsersComponent</a>
                                        </li>
                                </ul>
                            </li>
                    </li>
                    <li class="link">
                        <a href="modules/UsersRoutingModule.html" data-type="entity-link">UsersRoutingModule</a>
                    </li>
                    <li class="link">
                        <a href="modules/WidgetsModule.html" data-type="entity-link">WidgetsModule</a>
                            <li class="chapter inner">
                                <div class="simple menu-toggler" data-toggle="collapse"
                                    ${ isNormalMode ? 'data-target="#components-links-module-WidgetsModule-21c2c30c4af1f3e1322cc7ff6c941f24"' : 'data-target="#xs-components-links-module-WidgetsModule-21c2c30c4af1f3e1322cc7ff6c941f24"' }>
                                    <span class="icon ion-md-cog"></span>
                                    <span>Components</span>
                                    <span class="icon ion-ios-arrow-down"></span>
                                </div>
                                <ul class="links collapse"
                                    ${ isNormalMode ? 'id="components-links-module-WidgetsModule-21c2c30c4af1f3e1322cc7ff6c941f24"' : 'id="xs-components-links-module-WidgetsModule-21c2c30c4af1f3e1322cc7ff6c941f24"' }>
                                        <li class="link">
                                            <a href="components/WidgetsComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules">WidgetsComponent</a>
                                        </li>
                                </ul>
                            </li>
                    </li>
                    <li class="link">
                        <a href="modules/WidgetsRoutingModule.html" data-type="entity-link">WidgetsRoutingModule</a>
                    </li>
            </ul>
        </li>
                <li class="chapter">
                    <div class="simple menu-toggler" data-toggle="collapse"
                        ${ isNormalMode ? 'data-target="#injectables-links"' : 'data-target="#xs-injectables-links"' }>
                        <span class="icon ion-md-arrow-round-down"></span>
                        <span>Injectables</span>
                        <span class="icon ion-ios-arrow-down"></span>
                    </div>
                    <ul class="links collapse"
                    ${ isNormalMode ? 'id="injectables-links"' : 'id="xs-injectables-links"' }>
                            <li class="link">
                                <a href="injectables/AlertifyService.html" data-type="entity-link">AlertifyService</a>
                            </li>
                            <li class="link">
                                <a href="injectables/AuthService.html" data-type="entity-link">AuthService</a>
                            </li>
                            <li class="link">
                                <a href="injectables/CustomerService.html" data-type="entity-link">CustomerService</a>
                            </li>
                            <li class="link">
                                <a href="injectables/EventLogService.html" data-type="entity-link">EventLogService</a>
                            </li>
                            <li class="link">
                                <a href="injectables/FileUploadService.html" data-type="entity-link">FileUploadService</a>
                            </li>
                            <li class="link">
                                <a href="injectables/ItemService.html" data-type="entity-link">ItemService</a>
                            </li>
                            <li class="link">
                                <a href="injectables/ItemTemplateService.html" data-type="entity-link">ItemTemplateService</a>
                            </li>
                            <li class="link">
                                <a href="injectables/OrderService.html" data-type="entity-link">OrderService</a>
                            </li>
                            <li class="link">
                                <a href="injectables/UserService.html" data-type="entity-link">UserService</a>
                            </li>
                    </ul>
                </li>
        <li class="chapter">
            <div class="simple menu-toggler" data-toggle="collapse"
            ${ isNormalMode ? 'data-target="#interceptors-links"' : 'data-target="#xs-interceptors-links"' }>
                <span class="icon ion-ios-swap"></span>
                <span>Interceptors</span>
                <span class="icon ion-ios-arrow-down"></span>
            </div>
            <ul class="links collapse"
            ${ isNormalMode ? 'id="interceptors-links"' : 'id="xs-interceptors-links"' }>
                    <li class="link">
                        <a href="interceptors/ErrorInterceptor.html" data-type="entity-link">ErrorInterceptor</a>
                    </li>
            </ul>
        </li>
        <li class="chapter">
            <div class="simple menu-toggler" data-toggle="collapse"
                ${ isNormalMode ? 'data-target="#interfaces-links"' : 'data-target="#xs-interfaces-links"' }>
                <span class="icon ion-md-information-circle-outline"></span>
                <span>Interfaces</span>
                <span class="icon ion-ios-arrow-down"></span>
            </div>
            <ul class="links collapse"
            ${ isNormalMode ? ' id="interfaces-links"' : 'id="xs-interfaces-links"' }>
                    <li class="link">
                        <a href="interfaces/Customer.html" data-type="entity-link">Customer</a>
                    </li>
                    <li class="link">
                        <a href="interfaces/DetailFile.html" data-type="entity-link">DetailFile</a>
                    </li>
                    <li class="link">
                        <a href="interfaces/EventLog.html" data-type="entity-link">EventLog</a>
                    </li>
                    <li class="link">
                        <a href="interfaces/Item.html" data-type="entity-link">Item</a>
                    </li>
                    <li class="link">
                        <a href="interfaces/ItemItemRelation.html" data-type="entity-link">ItemItemRelation</a>
                    </li>
                    <li class="link">
                        <a href="interfaces/ItemPropertyDescription.html" data-type="entity-link">ItemPropertyDescription</a>
                    </li>
                    <li class="link">
                        <a href="interfaces/ItemPropertyName.html" data-type="entity-link">ItemPropertyName</a>
                    </li>
                    <li class="link">
                        <a href="interfaces/ItemTemplate.html" data-type="entity-link">ItemTemplate</a>
                    </li>
                    <li class="link">
                        <a href="interfaces/ItemTemplatePart.html" data-type="entity-link">ItemTemplatePart</a>
                    </li>
                    <li class="link">
                        <a href="interfaces/Order.html" data-type="entity-link">Order</a>
                    </li>
                    <li class="link">
                        <a href="interfaces/User.html" data-type="entity-link">User</a>
                    </li>
                    <li class="link">
                        <a href="interfaces/UserRole.html" data-type="entity-link">UserRole</a>
                    </li>
            </ul>
        </li>
        <li class="chapter">
            <div class="simple menu-toggler" data-toggle="collapse"
            ${ isNormalMode ? 'data-target="#miscellaneous-links"' : 'data-target="#xs-miscellaneous-links"' }>
                <span class="icon ion-ios-cube"></span>
                <span>Miscellaneous</span>
                <span class="icon ion-ios-arrow-down"></span>
            </div>
            <ul class="links collapse"
            ${ isNormalMode ? 'id="miscellaneous-links"' : 'id="xs-miscellaneous-links"' }>
                    <li class="link">
                      <a href="miscellaneous/enumerations.html" data-type="entity-link">Enums</a>
                    </li>
                    <li class="link">
                      <a href="miscellaneous/functions.html" data-type="entity-link">Functions</a>
                    </li>
                    <li class="link">
                      <a href="miscellaneous/variables.html" data-type="entity-link">Variables</a>
                    </li>
            </ul>
        </li>
            <li class="chapter">
                <a data-type="chapter-link" href="routes.html"><span class="icon ion-ios-git-branch"></span>Routes</a>
            </li>
        <li class="chapter">
            <a data-type="chapter-link" href="coverage.html"><span class="icon ion-ios-stats"></span>Documentation coverage</a>
        </li>
        <li class="divider"></li>
        <li class="copyright">
                Documentation generated using <a href="https://compodoc.app/" target="_blank">
                            <img data-src="images/compodoc-vectorise.svg" class="img-responsive" data-type="compodoc-logo">
                </a>
        </li>
    </ul>
</nav>`);
        this.innerHTML = tp.strings;
    }
});
