class TemplateLoader {
    static async loadTemplate(templatePath, data = {}) {
        try {
            const response = await fetch(templatePath);
            let template = await response.text();
            
            // Substituir variáveis
            Object.keys(data).forEach(key => {
                const regex = new RegExp(`{{${key}}}`, 'g');
                template = template.replace(regex, data[key]);
            });
            
            return template;
        } catch (error) {
            console.error('Erro ao carregar template:', error);
            return '';
        }
    }

    static async includeTemplates() {
        const includes = document.querySelectorAll('[data-include]');
        
        for (const element of includes) {
            const templatePath = element.getAttribute('data-include');
            const templateData = JSON.parse(element.getAttribute('data-template-vars') || '{}');
            
            const content = await this.loadTemplate(templatePath, templateData);
            element.innerHTML = content;
        }
    }
} 