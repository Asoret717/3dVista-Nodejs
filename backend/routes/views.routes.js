module.exports = app => {
    const views = require("../controllers/views.controller.js");
    const auth = require("../controllers/auth.js");
  
    var router = require("express").Router();
  
    // Create a new Image
    router.post("/", views.create);
  
    // Retrieve all Images
    router.get("/", views.findAll);

    // Retrieve a single Image with id
    router.get("/:id", views.findOne);
  
    // Update a Image with id
    router.put("/:id", views.update);
  
    // Delete a Image with id
    router.delete("/:id", views.delete);
  
    app.use('/api/views', router);
  };