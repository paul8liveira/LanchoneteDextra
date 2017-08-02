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
* Utilizado ferramenta padrão do Visual Studio para criação dos testes unitários. Infelizmente não sei o que houve, no momento da execução do primeiro teste ocorreu o erro `could not connect to test process vstest.discoveryengine.x86.exe`. Não encontrei nada na internet que me ajudasse por isso, não finalizei o processo de testes.
