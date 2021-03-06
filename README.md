# Lanchonete Dextra
Projeto Desafio Dextra

**Justificativa para utilização do design no código**
* Utilizado método DDD (Domain Driven Design) como abordagem para modelagem do projeto, com arquitetura em 4 camadas (Presentation, Application, Domain e Data) comunicando-se através de injeção de dependência. Utilizo a pouco tempo essa abordagem mas, acredito que, um dos melhores argumentos para uso seja devido sua estruturação em camadas, isso permite a organização das responsabilidades e também facilita a manutenção e geração de testes.

**Documentação para construção e execução**
* **IDE e Framework**
	* Visual Studio 2017
	* .NET Framework 4.5
	* MVC 4

**Antes da construção e execução**
* Atualizar referências dos projetos.   
	* Simplesmente no ato da execução do projeto o nuget fará a atualização necessária das referências.
	
**Teste unitário com MSTest**
* Utilizado ferramenta padrão do Visual Studio para criação dos testes unitários. Cobertura de testes feito em:
	* Cálculo padrão dos lanches do cardápio
	* Cálculo Personalizado Preço Light
	* Cálculo Personalizado Muita Carne
	* Cálculo Personalizado Muito Queijo
	* Cálculo Personalizado Inflação

**Telas**
* <a href="https://drive.google.com/file/d/0B12drrbK1f36cWR1d24zYnJ5c0E/view" target="_blank">Comprando lanche personalizado</a>
* <a href="https://drive.google.com/file/d/0B12drrbK1f36VEp4aEEzcXhWT1U/view" target="_blank">Comprando lanche do cardápio</a>