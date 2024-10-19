// script.js

const apiUrl = "https://localhost:7158/api/ItemAPI"; // Adjust this to your API URL
const itemTableBody = document.getElementById("itemTableBody");
const totalInventory = document.getElementById("totalInventory");
const searchInput = document.getElementById("searchInput");
const categoryFilter = document.getElementById("categoryFilter");
const supplierFilter = document.getElementById("supplierFilter");

// Fetch items from the API and populate the table
async function fetchItems() {
    const searchTerm = searchInput.value;
    const category = categoryFilter.value;
    const supplier = supplierFilter.value;
    let url = `${apiUrl}?searchTerm=${searchTerm}`;

    if (category) {
        url += `&category=${category}`;
    }
    if (supplier) {
        url += `&supplier=${supplier}`;
    }

    try {
        const response = await fetch(url);
        const items = await response.json();
        displayItems(items);
        updateTotalInventory(items);
    } catch (error) {
        console.error("Error fetching items:", error);
    }
}

// Display items in the table
function displayItems(items) {
    itemTableBody.innerHTML = ""; // Clear previous items
    items.forEach((item) => {
        const row = document.createElement("tr");
        row.innerHTML = `
            <td>${item.itemName}</td>
            <td>${item.quantity}</td>
            <td>${item.category}</td>
            <td>${item.supplier}</td>
            <td>
                <button class="action-button update-button" onclick="updateItem(${item.id})">Update</button>
                <button class="action-button delete-button" onclick="deleteItem(${item.id})">Delete</button>
            </td>
        `;
        itemTableBody.appendChild(row);
    });
}

// Update total inventory count
function updateTotalInventory(items) {
    const total = items.reduce((sum, item) => sum + item.quantity, 0);
    totalInventory.innerText = `Total Inventory: ${total}`;
}

// Add a new item
document.getElementById("addButton").addEventListener("click", async () => {
    const itemName = document.getElementById("item").value;
    const quantity = parseInt(document.getElementById("quantity").value);
    const category = document.getElementById("category").value;
    const supplier = document.getElementById("supplier").value;

    const newItem = { itemName, quantity, category, supplier };

    try {
        const response = await fetch(apiUrl, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(newItem),
        });

        if (response.ok) {
            fetchItems(); // Refresh the item list
            clearForm();
        } else {
            console.error("Failed to add item:", response.statusText);
        }
    } catch (error) {
        console.error("Error adding item:", error);
    }
});

// Clear input fields after adding an item
function clearForm() {
    document.getElementById("item").value = "";
    document.getElementById("quantity").value = "";
    document.getElementById("category").value = "";
    document.getElementById("supplier").value = "";
}

// Update item
async function updateItem(itemId) {
    const newQuantity = prompt("Enter new quantity:");
    if (newQuantity !== null) {
        try {
            const response = await fetch(`${apiUrl}/${itemId}`, {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({ quantity: parseInt(newQuantity) }),
            });

            if (response.ok) {
                fetchItems(); // Refresh the item list
            } else {
                console.error("Failed to update item:", response.statusText);
            }
        } catch (error) {
            console.error("Error updating item:", error);
        }
    }
}

// Delete item
async function deleteItem(itemId) {
    if (confirm("Are you sure you want to delete this item?")) {
        try {
            const response = await fetch(`${apiUrl}/${itemId}`, {
                method: "DELETE",
            });

            if (response.ok) {
                fetchItems(); // Refresh the item list
            } else {
                console.error("Failed to delete item:", response.statusText);
            }
        } catch (error) {
            console.error("Error deleting item:", error);
        }
    }
}

// Initial fetch of items when the page loads
window.onload = fetchItems;
