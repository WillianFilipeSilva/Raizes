class Sidebar {
    constructor(menuItems, userData) {
        this.menuItems = menuItems;
        this.userData = userData;
        this.isExpanded = false;
        this.activeSubmenu = null;
        this.propriedades = [];
        this.loadPropriedades();
    }

    static init(containerId, menuItems, userData) {
        this.container = document.getElementById(containerId);
        this.isExpanded = false;
        this.activeSubmenu = null;
        this.render(menuItems, userData);
        this.setupEventListeners();
    }

    static render(menuItems, userData) {
        const sidebar = document.createElement('div');
        sidebar.id = 'sidebar';
        sidebar.className = 'fixed h-full bg-[#2F4F2F] flex flex-col py-5 text-white transition-all duration-300 rounded-r-xl cursor-pointer';
        sidebar.style.width = '5rem';
        sidebar.style.zIndex = '50';

        sidebar.innerHTML = `
            <!-- Logo Section -->
            <div class="logo-container">
                <img src="../assets/imagens/logo/LogoRaizes.svg" alt="Logo">
                <img src="../assets/imagens/logo/EscritaRaizes.svg" alt="Raízes" class="h-8 hidden ml-3" id="logo-text">
            </div>

            <div class="divider"></div>
            
            <!-- Menu Grid -->
            <div class="grid grid-cols-1 gap-2 px-3">
                <!-- Menu Items -->
                <div class="grid grid-cols-1 gap-2">
                    ${this.renderMenuItems(menuItems)}
                </div>
            </div>

            <div class="divider"></div>

            <!-- Footer Section -->
            <div class="mt-auto grid grid-cols-1">
                ${this.renderProfile(userData)}
            </div>
        `;

        this.container.appendChild(sidebar);
    }

    static renderMenuItems(items) {
        return items.map((item, index) => {
            if (item.type === 'submenu') {
                const isPropriedades = item.label === 'Propriedades';
                const btnId = isPropriedades ? 'propriedades-btn' : 'relatorios-btn';
                const submenuId = isPropriedades ? 'propriedades-submenu' : 'relatorios-submenu';
                
                return `
                    <div class="relative">
                        <a href="#" class="menu-item hover-white rounded-xl group" id="${btnId}">
                            <div class="icon-container">
                                <img src="${item.icon}" alt="${item.label}">
                            </div>
                            <div class="menu-text hidden pl-3 flex-1">
                                <span class="text-sm">${item.label}</span>
                            </div>
                            <svg class="w-4 h-4 arrow-icon hidden ml-auto mr-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7"></path>
                            </svg>
                        </a>
                        <div class="submenu-container hidden" id="${submenuId}">
                            <div class="submenu-line"></div>
                            ${item.submenuItems.map(subItem => `
                                <a href="${subItem.href}" class="submenu-item block hover-white">
                                    <span class="text-sm">${subItem.label}</span>
                                </a>
                            `).join('')}
                        </div>
                    </div>
                `;
            }

            return `
                <a href="${item.href}" class="menu-item hover-white rounded-xl group transition-all duration-800">
                    <div class="icon-container">
                        <img src="${item.icon}" alt="${item.label}">
                    </div>
                    <div class="hidden menu-text pl-3 flex-1">
                        <span class="text-sm">${item.label}</span>
                    </div>
                </a>
            `;
        }).join('');
    }

    static renderProfile(userData) {
        return `
            <a href="#" class="menu-item hover-white rounded-xl profile-menu-item transition-all duration-800">
                <div class="avatar-container">
                    <img src="${userData.avatar}" alt="Avatar">
                </div>
                <div class="hidden menu-text pl-3 flex-1">
                    <span class="text-sm">${userData.name}</span>
                </div>
            </a>

            <div class="divider"></div>

            <div class="grid grid-cols-1 gap-2 px-3">
                <a href="#" class="menu-item hover-white rounded-xl group transition-all duration-800">
                    <div class="icon-container">
                        <img src="../assets/imagens/icones/Icone-Configuracoes.svg" alt="Configurações">
                    </div>
                    <div class="hidden menu-text pl-3 flex-1">
                        <span class="text-sm">Configurações</span>
                    </div>
                </a>
                
                <a href="#" class="menu-item hover-white rounded-xl group transition-all duration-800 text-red-400">
                    <div class="icon-container">
                        <img src="../assets/imagens/icones/Icone-Sair.svg" alt="Sair">
                    </div>
                    <div class="hidden menu-text pl-3 flex-1">
                        <span class="text-sm">Sair</span>
                    </div>
                </a>
            </div>
        `;
    }

    static setupEventListeners() {
        const sidebar = document.getElementById('sidebar');
        const logoText = document.getElementById('logo-text');
        const menuTexts = document.querySelectorAll('.menu-text');
        const submenus = {
            propriedades: {
                btn: document.getElementById('propriedades-btn'),
                submenu: document.getElementById('propriedades-submenu'),
                arrow: document.querySelector('#propriedades-btn .arrow-icon')
            },
            relatorios: {
                btn: document.getElementById('relatorios-btn'),
                submenu: document.getElementById('relatorios-submenu'),
                arrow: document.querySelector('#relatorios-btn .arrow-icon')
            }
        };

        const toggleSubmenu = (event, type) => {
            event.preventDefault();
            event.stopPropagation();
            
            const currentSubmenu = submenus[type];
            const otherType = type === 'propriedades' ? 'relatorios' : 'propriedades';
            const otherSubmenu = submenus[otherType];
            
            if (!this.isExpanded) {
                this.toggleSidebar();
                setTimeout(() => {
                    this.showSubmenu(currentSubmenu, otherSubmenu);
                }, 400);
            } else {
                this.showSubmenu(currentSubmenu, otherSubmenu);
            }
        };

        const showSubmenu = (currentSubmenu, otherSubmenu) => {
            // Fecha o outro submenu se estiver aberto
            if (otherSubmenu.submenu && !otherSubmenu.submenu.classList.contains('hidden')) {
                otherSubmenu.submenu.classList.remove('show');
                otherSubmenu.arrow.classList.remove('rotated');
                otherSubmenu.submenu.classList.add('hidden');
            }

            // Toggle do submenu atual
            const isCurrentOpen = !currentSubmenu.submenu.classList.contains('hidden');
            if (isCurrentOpen) {
                currentSubmenu.submenu.classList.remove('show');
                currentSubmenu.arrow.classList.remove('rotated');
                currentSubmenu.submenu.classList.add('hidden');
            } else {
                currentSubmenu.submenu.classList.remove('hidden');
                requestAnimationFrame(() => {
                    currentSubmenu.submenu.classList.add('show');
                    currentSubmenu.arrow.classList.add('rotated');
                });
            }
        };

        const toggleSidebar = (event) => {
            if (event && (event.target.closest('#propriedades-btn') || event.target.closest('#relatorios-btn'))) {
                return;
            }
            
            this.isExpanded = !this.isExpanded;
            
            if (this.isExpanded) {
                sidebar.style.width = '16rem';
                menuTexts.forEach(el => {
                    el.classList.remove('hidden');
                    requestAnimationFrame(() => {
                        el.classList.remove('shrinking');
                    });
                });
                logoText.classList.remove('hidden');
                Object.values(submenus).forEach(({arrow}) => arrow.classList.remove('hidden'));
                requestAnimationFrame(() => {
                    logoText.classList.remove('shrinking');
                    Object.values(submenus).forEach(({arrow}) => arrow.classList.remove('shrinking'));
                });
            } else {
                menuTexts.forEach(el => el.classList.add('shrinking'));
                logoText.classList.add('shrinking');
                Object.values(submenus).forEach(({arrow}) => arrow.classList.add('shrinking'));
                
                // Fecha todos os submenus
                Object.values(submenus).forEach(({submenu, arrow}) => {
                    if (submenu && !submenu.classList.contains('hidden')) {
                        submenu.classList.remove('show');
                        arrow.classList.remove('rotated');
                        submenu.classList.add('hidden');
                    }
                });

                requestAnimationFrame(() => {
                    sidebar.style.width = '5rem';
                });
                
                setTimeout(() => {
                    menuTexts.forEach(el => el.classList.add('hidden'));
                    logoText.classList.add('hidden');
                    Object.values(submenus).forEach(({arrow}) => arrow.classList.add('hidden'));
                }, 800);
            }
        };

        // Bind dos métodos ao contexto da classe
        this.showSubmenu = showSubmenu.bind(this);
        this.toggleSidebar = toggleSidebar.bind(this);

        // Event listeners
        submenus.propriedades.btn.addEventListener('click', (e) => toggleSubmenu(e, 'propriedades'));
        submenus.relatorios.btn.addEventListener('click', (e) => toggleSubmenu(e, 'relatorios'));
        sidebar.addEventListener('click', toggleSidebar.bind(this));
    }

    async loadPropriedades() {
        try {
            const response = await fetch('http://localhost:5000/api/propriedades');
            this.propriedades = await response.json();
            this.renderPropriedades();
        } catch (error) {
            console.error('Erro ao carregar propriedades:', error);
        }
    }

    renderPropriedades() {
        const submenuContainer = document.querySelector('.submenu-container');
        if (!submenuContainer) return;

        const html = this.propriedades.map(prop => `
            <a href="#" class="submenu-item hover:bg-white hover:text-black">
                ${prop}
            </a>
        `).join('');

        submenuContainer.innerHTML = html;
    }
}

// Inicializa a sidebar
document.addEventListener('DOMContentLoaded', () => {
    const sidebar = new Sidebar();
}); 