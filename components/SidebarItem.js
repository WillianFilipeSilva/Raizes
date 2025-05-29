class SidebarItem extends HTMLElement {
    constructor() {
        super();
        this.attachShadow({ mode: 'open' });
    }

    static get observedAttributes() {
        return ['icon', 'label', 'href'];
    }

    connectedCallback() {
        this.render();
    }

    render() {
        const icon = this.getAttribute('icon');
        const label = this.getAttribute('label');
        const href = this.getAttribute('href');

        this.shadowRoot.innerHTML = `
            <style>
                /* Importando Tailwind */
                @import url('https://cdn.tailwindcss.com');

                :host {
                    display: block;
                }
            </style>
            <a href="${href}" class="menu-item hover-white rounded-xl group transition-all duration-800">
                <div class="icon-container">
                    <img src="${icon}" alt="${label}">
                </div>
                <div class="hidden menu-text pl-3 flex-1">
                    <span class="text-sm">${label}</span>
                </div>
            </a>
        `;
    }
}

customElements.define('sidebar-item', SidebarItem); 