module.exports = (sequelize, Sequelize) => {
    const View = sequelize.define("view", {
        name: {
            type: Sequelize.STRING
        },
        views: {
            type: Sequelize.INTEGER
        }
    });
    return View;
};