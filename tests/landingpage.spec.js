// @ts-check
import {test, expect} from '@playwright/test';

test.describe('Buy Gas', () => {
    test('Can Buy Gas', async ({page, baseURL}) => {
        // Visit the base URL from config
        await page.goto(`${baseURL}/Energy/Buy`);
        const amountToBuy = 100;

        const table = await page.locator('.table');
        await expect(table).toBeVisible();

        // Check if the text "3000" exists inside the element
        const tableText = await table.textContent();

        if (tableText?.includes('3000') == false) {
            const resetButton = page.locator('input:has-text("Reset")').first();
            await resetButton.click();
        }

        const resetButton = page.locator('input:has-text("Reset")').first();
        await resetButton.click();

        const gasAmountInput = page
            .locator('#energyType_AmountPurchased')
            .first();
        await gasAmountInput.fill(amountToBuy.toString());
        const buyButton = page.locator('input:has-text("Buy")').first();
        await buyButton.click();
        const confirmationMessage = page.locator('text=Sale Confirmed!');
        await expect(confirmationMessage).toBeVisible();

        const wellElement = page.locator('.well');
        await expect(wellElement).toContainText(`${3000 - amountToBuy}`);
    });
});
