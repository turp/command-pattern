# Project Structure

The project is organized into the following main components:

1. **Controllers**: This directory contains the controller classes that handle HTTP requests and responses.
2. **Models**: This directory contains the data models that represent the entities in the application.
3. **Repositories**: This directory contains the repository classes that handle data access and storage.
4. **Services**: This directory contains the service classes that contain the business logic of the application.
5. **Views**: This directory contains the view templates used to render the HTML pages.

# Creating New Compliance Controls

To create a new Compliance Control, follow these steps:

1. **Define the Model**:
   Create a new model class in the `Models` directory to represent the Compliance Control entity. For example:

   ```python
   # models/compliance_control.py
   class ComplianceControl:
        def __init__(self, id, name, description):
             self.id = id
             self.name = name
             self.description = description
   ```

2. **Create the Repository**:
   Create a new repository class in the `Repositories` directory to handle data access for the Compliance Control entity. For example:

   ```python
   # repositories/compliance_control_repository.py
   class ComplianceControlRepository:
        def __init__(self):
             self.controls = []

        def add_control(self, control):
             self.controls.append(control)

        def get_control(self, id):
             return next((c for c in self.controls if c.id == id), None)
   ```

3. **Implement the Service**:
   Create a new service class in the `Services` directory to contain the business logic for Compliance Controls. For example:

   ```python
   # services/compliance_control_service.py
   class ComplianceControlService:
        def __init__(self, repository):
             self.repository = repository

        def create_control(self, id, name, description):
             control = ComplianceControl(id, name, description)
             self.repository.add_control(control)
             return control
   ```

4. **Create the Controller**:
   Create a new controller class in the `Controllers` directory to handle HTTP requests related to Compliance Controls. For example:

   ```python
   # controllers/compliance_control_controller.py
   class ComplianceControlController:
        def __init__(self, service):
             self.service = service

        def create_control(self, request):
             id = request.get('id')
             name = request.get('name')
             description = request.get('description')
             control = self.service.create_control(id, name, description)
             return control
   ```

5. **Define the Routes**:
   Define the routes in your web framework to map HTTP requests to the controller actions. For example:

   ```python
   # routes.py
   from controllers.compliance_control_controller import ComplianceControlController
   from services.compliance_control_service import ComplianceControlService
   from repositories.compliance_control_repository import ComplianceControlRepository

   repository = ComplianceControlRepository()
   service = ComplianceControlService(repository)
   controller = ComplianceControlController(service)

   def setup_routes(app):
        app.route('/compliance_controls', methods=['POST'])(controller.create_control)
   ```

By following these steps, you can create new Compliance Controls and integrate them into your application.
