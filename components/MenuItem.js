class MenuItem {
    constructor(icon, label, href) {
        this.icon = icon;
        this.label = label;
        this.href = href;
    }

    render() {
        return `
            <a href="${this.href}" class="menu-item hover-white rounded-xl group transition-all duration-800">
                <div class="icon-container">
                    <img src="${this.icon}" alt="${this.label}">
                </div>
                <div class="hidden menu-text pl-3 flex-1">
                    <span class="text-sm">${this.label}</span>
                </div>
            </a>
        `;
    }

    static create(container, items) {
        items.forEach(item => {
            const menuItem = new MenuItem(item.icon, item.label, item.href);
            container.innerHTML += menuItem.render();
        });
    }
} 