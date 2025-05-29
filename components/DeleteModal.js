class DeleteModal {
    constructor() {
        this.modalHTML = `
            <div id="deleteModal" class="fixed inset-0 bg-black bg-opacity-50 hidden items-center justify-center" style="z-index: 1000;">
                <div class="bg-white rounded-2xl p-8 max-w-md w-full mx-4 relative">
                    <!-- Botão de fechar -->
                    <button onclick="DeleteModal.close()" class="absolute right-4 top-4 text-gray-500 hover:text-gray-700">
                        <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12"></path>
                        </svg>
                    </button>

                    <!-- Conteúdo da Modal -->
                    <div class="text-center">
                        <div class="mx-auto flex items-center justify-center h-16 w-16 rounded-full bg-red-100 mb-6">
                            <img src="../assets/imagens/icones/Icone-Deletar.svg" alt="Deletar" class="w-8 h-8" style="filter: invert(22%) sepia(93%) saturate(6449%) hue-rotate(356deg) brightness(97%) contrast(119%);">
                        </div>
                        <h3 class="text-2xl font-semibold text-gray-900 mb-4">Deletar</h3>
                        <p class="text-gray-500 mb-8">Tem certeza que deseja fazer isso?</p>
                        
                        <!-- Botões -->
                        <div class="flex gap-4">
                            <button onclick="DeleteModal.close()" class="flex-1 px-4 py-3 text-gray-800 border border-gray-300 rounded-lg hover:bg-gray-50 transition-colors duration-150">
                                Cancelar
                            </button>
                            <button onclick="DeleteModal.confirm()" class="flex-1 px-4 py-3 bg-red-600 text-white rounded-lg hover:bg-red-700 transition-colors duration-150">
                                Confirmar
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        `;
    }

    static init(containerId = 'modal-container') {
        if (!DeleteModal.instance) {
            DeleteModal.instance = new DeleteModal();
            
            // Criar container se não existir
            let container = document.getElementById(containerId);
            if (!container) {
                container = document.createElement('div');
                container.id = containerId;
                document.body.appendChild(container);
            }
            
            // Adicionar HTML da modal
            container.innerHTML = DeleteModal.instance.modalHTML;
            
            // Configurar evento de clique fora
            const modal = document.getElementById('deleteModal');
            modal.addEventListener('click', (e) => {
                if (e.target === modal) {
                    DeleteModal.close();
                }
            });
        }
    }

    static open(itemId, onConfirm) {
        const modal = document.getElementById('deleteModal');
        DeleteModal.itemToDeleteId = itemId;
        DeleteModal.onConfirmCallback = onConfirm;
        modal.classList.remove('hidden');
        modal.classList.add('flex');
    }

    static close() {
        const modal = document.getElementById('deleteModal');
        modal.classList.add('hidden');
        modal.classList.remove('flex');
        DeleteModal.itemToDeleteId = null;
        DeleteModal.onConfirmCallback = null;
    }

    static confirm() {
        if (DeleteModal.onConfirmCallback && DeleteModal.itemToDeleteId) {
            DeleteModal.onConfirmCallback(DeleteModal.itemToDeleteId);
        }
        DeleteModal.close();
    }
} 