# Diretrizes de Desenvolvimento - Projeto Raízes

## Estrutura Base e Componentes Principais
- Os arquivos `base.html` e a barra lateral são componentes CORE do sistema
- NUNCA modificar estes arquivos sem autorização (senha: raizes@admin2024)
- Alterações no base.html ou sidebar SOMENTE com a senha autorizada no chat

## Componentes do Sistema
### 1. Verificação de Componentes Existentes
- SEMPRE verificar se já existe um componente para a funcionalidade desejada
- Lista de componentes disponíveis:
  - `DeleteModal.js`: Modal de confirmação para exclusão
  - `Sidebar.js`: Barra lateral de navegação
  - [Adicionar novos componentes à lista conforme criados]

### 2. Criação de Novos Componentes
- Se a funcionalidade não existir como componente:
  1. Criar novo componente em `/components`
  2. Seguir padrão de nomenclatura: `NomeComponente.js`
  3. Implementar como classe com métodos estáticos
  4. Documentar uso básico no código
  
### 3. Regras para Componentes
- NUNCA modificar componentes existentes
- NUNCA adicionar funcionalidades a componentes existentes
- SEMPRE criar um novo componente para novas funcionalidades
- Exemplos de quando criar novos componentes:
  - Modais específicas (EditModal, DetailModal)
  - Widgets reutilizáveis
  - Elementos de UI comuns entre telas

### 4. Uso de Componentes
- Ao implementar uma funcionalidade:
  1. Primeiro: Verificar se existe componente
  2. Se existir: Usar o componente conforme documentação
  3. Se não existir: Criar novo componente
  4. Nunca: Modificar componente existente

## Criação de Novas Telas
### 1. Nomenclatura Padrão
- SEMPRE seguir o padrão de nomenclatura:
  - Listagens: `Listar[Entidade]` (ex: `ListarPropriedades.html`, `ListarPlantios.html`)
  - Cadastros: `Cadastrar[Entidade]` (ex: `CadastrarPropriedades.html`, `CadastrarPlantios.html`)
  - Edição: `Editar[Entidade]` (ex: `EditarPropriedades.html`, `EditarPlantios.html`)
  - Detalhes: `Detalhar[Entidade]` (ex: `DetalharPropriedades.html`, `DetalharPlantios.html`)

### 2. Processo de Criação
1. SEMPRE começar copiando o arquivo `base.html` como template
2. Renomear seguindo o padrão de nomenclatura
3. Manter a estrutura base intacta:
   - Header com configurações Tailwind
   - Importações CSS base
   - Container da Sidebar
   - Scripts base
4. Modificar apenas o conteúdo dentro da div principal:
   ```html
   <!-- Container Principal -->
   <div class="ml-20 p-8 h-screen flex flex-col">
       <!-- Seu conteúdo aqui -->
   </div>
   ```

### 3. Estrutura de Arquivos por Tela
```
Raizes/
├── templates/
│   ├── base.html
│   ├── ListarPropriedades.html
│   ├── CadastrarPropriedades.html
│   ├── EditarPropriedades.html
│   └── ...
├── assets/
│   ├── styles/
│   │   ├── listar-propriedades.css
│   │   ├── cadastrar-propriedades.css
│   │   └── ...
│   └── js/
│       ├── listar-propriedades.js
│       ├── cadastrar-propriedades.js
│       └── ...
```

## Padrões de Desenvolvimento

### 1. Estilização e Cores
- SEMPRE utilizar as variáveis CSS definidas no sistema:
  - Cores primárias: `var(--primary-color)`
  - Cores secundárias: `var(--secondary-color)`
  - Cores terciárias: `var(--tertiary-color)`
  - Estados hover: `var(--primary-hover)`, `var(--secondary-hover)`, `var(--tertiary-hover)`
  - Textos: `var(--text-primary)`, `var(--text-secondary)`, `var(--text-light)`
  - Bordas: `var(--border-color)`

### 2. Estrutura de Arquivos
- Cada nova tela deve:
  - Herdar a estrutura do `base.html`
  - Importar a Sidebar e outros componentes necessários
  - Ter seus próprios arquivos CSS/JS quando necessário, seguindo o padrão:
    ```
    Raizes/
    ├── assets/
    │   ├── styles/
    │   │   ├── nome-da-tela.css
    │   │   └── ...
    │   └── js/
    │       ├── nome-da-tela.js
    │       └── ...
    ```

### 3. Componentes Reutilizáveis
- Usar os componentes existentes conforme implementados:
  - DeleteModal: Para confirmações de exclusão
  - Sidebar: Para navegação lateral
- Novos componentes devem seguir o mesmo padrão de implementação dos existentes

### 4. Regras de Modificação
- NUNCA modificar métodos existentes
- NUNCA alterar a estrutura da barra lateral
- SEMPRE criar novos arquivos para novas funcionalidades
- SEMPRE manter compatibilidade com funcionalidades existentes

### 5. Implementação de Novas Telas
1. Criar arquivo HTML estendendo base.html
2. Importar componentes necessários:
   ```html
   <script src="../components/Sidebar.js"></script>
   <script src="../components/DeleteModal.js"></script>
   ```
3. Inicializar componentes:
   ```javascript
   document.addEventListener('DOMContentLoaded', () => {
       Sidebar.init('sidebar-container', menuItems, userData);
       // Outros componentes necessários
   });
   ```
4. Seguir o padrão visual existente usando as variáveis CSS do sistema

### 6. CSS Específico
- Se necessário CSS específico para uma tela:
  1. Criar arquivo `nome-da-tela.css` em `assets/styles/`
  2. Importar após os estilos base:
     ```html
     <link rel="stylesheet" href="../assets/styles/variables.css">
     <link rel="stylesheet" href="../assets/styles/sidebar.css">
     <link rel="stylesheet" href="../assets/styles/nome-da-tela.css">
     ```

### 7. JavaScript Específico
- Se necessário JS específico para uma tela:
  1. Criar arquivo `nome-da-tela.js` em `assets/js/`
  2. Importar após os componentes base:
     ```html
     <script src="../assets/js/nome-da-tela.js"></script>
     ```

### 8. Padrões de Código
- Usar classes Tailwind conforme implementado no base.html
- Manter consistência com os estilos de botões, cards e elementos existentes
- Seguir o padrão de nomeação de arquivos e classes já estabelecido

### 9. Segurança
- Nunca expor dados sensíveis no frontend
- Sempre usar event.stopPropagation() em botões dentro de elementos clicáveis
- Validar inputs antes de qualquer operação

### 10. Performance
- Carregar apenas os recursos necessários para cada tela
- Reutilizar componentes existentes sempre que possível
- Evitar duplicação de código

## IMPORTANTE
- Qualquer alteração em arquivos core (base.html, sidebar) DEVE ser aprovada com senha
- Manter a consistência visual e funcional do sistema
- Em caso de dúvida, consultar implementações existentes como referência
- SEMPRE começar novas telas copiando o base.html 