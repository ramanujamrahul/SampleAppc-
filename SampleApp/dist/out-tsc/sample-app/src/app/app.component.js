import { __decorate } from "tslib";
import { Component } from '@angular/core';
let AppComponent = class AppComponent {
    constructor() {
        this.title = 'sample-app';
    }
};
AppComponent = __decorate([
    Component({
        selector: 'my-app',
        template: `
    <!--The content below is only a placeholder and can be replaced.-->
    <div style="text-align:center" class="content">
      <h1>
        Welcome to {{title}}!
      </h1>
       </div>  
  `,
        styles: []
    })
], AppComponent);
export { AppComponent };
//# sourceMappingURL=app.component.js.map