const db = require("../models");
const View = db.view;
const Op = db.Sequelize.Op;

// Create and Save a new Image
exports.create = (req, res) => {
  // Validate request
  if (!req.body.name || !req.body.views) {
    res.status(400).send({
      message: "Content of view is empty!"
    });
    return;
  }

  // Create a Image
  const view = {
    name: req.body.name,
    views: req.body.views
  };

  // Save Image in the database
  View.create(view)
    .then(data => {
      res.send(data);
    })
    .catch(err => {
      res.status(500).send({
        message:
          err.message || "Some error occurred while creating the View."
      });
    });
};

// Retrieve all Images from the database.
exports.findAll = (req, res) => {
  View.findAll()
    .then(data => {
      res.send(data);
    })
    .catch(err => {
      res.status(500).send({
        message:
          err.message || "Some error occurred while retrieving views."
      });
    });
};

// Find a single Image with an id
exports.findOne = (req, res) => {
  const id = req.params.id;

  View.findByPk(id)
    .then(data => {
      res.send(data);
    })
    .catch(err => {
      res.status(500).send({
        message: "Error retrieving View with id=" + id
      });
    });
};

// Update a Image by the id in the request
exports.update = (req, res) => {
  const id = req.params.id;

  View.update(req.body, {
    where: { id: id }
  })
    .then(num => {
      if (num == 1) {
        res.send({
          message: "View was updated successfully."
        });
      } else {
        res.send({
          message: `Cannot update View with id=${id}. Maybe View was not found or req.body is empty!`
        });
      }
    })
    .catch(err => {
      res.status(500).send({
        message: "Error updating View with id=" + id
      });
    });
};

// Delete a Image with the specified id in the request
exports.delete = (req, res) => {
  const id = req.params.id;

  View.destroy({
    where: { id: id }
  })
    .then(num => {
      if (num == 1) {
        res.send({
          message: "View was deleted successfully!"
        });
      } else {
        res.send({
          message: `Cannot delete View with id=${id}. Maybe View was not found!`
        });
      }
    })
    .catch(err => {
      res.status(500).send({
        message: "Could not delete View with id=" + id
      });
    });
};