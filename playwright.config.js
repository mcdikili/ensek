// @ts-check
import {devices} from '@playwright/test';

/**
 * @see https://playwright.dev/docs/test-configuration
 */
// /** @type {import('@playwright/test').PlaywrightTestConfig} */
const config = {
    author: 'Ismail Dikili',
    forbidOnly: !!process.env.CI,
    fullyParallel: true,
    retries: process.env.CI ? 2 : 0,
    use: {
        baseURL: 'https://ensekautomationcandidatetest.azurewebsites.net/',
        trace: 'on-first-retry',
    },
    projects: [
        {
            name: 'chromium',
            use: {...devices['Desktop Chrome']},
        },
        // {
        //     name: 'Mobile Safari',
        //     use: {
        //         ...devices['iPhone 13'],
        //     },
        // },
    ],
    reporter: [
        [
            'junit',
            {
                outputFile:
                    'test-results/' +
                    `js-${new Date()
                        .toISOString()
                        .substring(0, 19)
                        .replace(/:/g, '.')}.xml`,
            },
        ],
    ],
};

module.exports = config;
