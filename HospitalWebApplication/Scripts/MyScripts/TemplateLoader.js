class TemplateLoader {
    constructor() {
        this.templateURLs = new Array();
        this.templateBodies = new Array();
    }
    registerTemplate(name, url) {
        this.templateURLs[name] = url;
    }

    get(name, f) {
        if (this.templateBodies[name]) {
            f(this.templateBodies[name])
        }
        else {
            $.get(this.templateURLs[name], function (template) {
                templateLoader.templateBodies[name] = template;
                f(template);
            });
        }
    }
}

var templateLoader = new TemplateLoader();