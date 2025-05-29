from flask import Flask, jsonify
from flask_cors import CORS

app = Flask(__name__)
CORS(app)

# Lista de propriedades (simulando um banco de dados)
propriedades = [
    "Fazenda São João",
    "Sítio Boa Vista",
    "Chácara Verde",
    "Fazenda Esperança",
    "Sítio Primavera"
]

@app.route('/api/propriedades', methods=['GET'])
def get_propriedades():
    # Retorna no máximo 5 propriedades
    return jsonify(propriedades[:5])

if __name__ == '__main__':
    app.run(debug=True, port=5000) 