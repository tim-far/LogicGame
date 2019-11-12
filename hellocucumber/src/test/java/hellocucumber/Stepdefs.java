package hellocucumber;

import cucumber.api.Scenario;
import cucumber.api.java.Before;
import cucumber.api.java.en.Given;
import cucumber.api.java.en.Then;
import cucumber.api.java.en.When;
import org.junit.Assert;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;

import java.util.List;
import java.util.concurrent.TimeUnit;


public class Stepdefs {

    WebDriver driver;

    @Before
    public void beforeScenario(Scenario scenario) {
        System.out.println("### Testing scenario '" + scenario.getName() + "' ###");
        System.setProperty("webdriver.chrome.driver", "C:/share/chromedriver.exe");

    }

    @Given("Chrome is running")
    public void chrome_is_started() {
        driver = new ChromeDriver();
        driver.manage().timeouts().implicitlyWait(20, TimeUnit.SECONDS);
        driver.manage().window().maximize();
    }

    @Given("The windows is maximized")
    public void chrome_is_maximized() {
        driver.manage().window().maximize();
    }

    @Given("The login testpage is open")
    public void the_login_test_is_open() {
        String baseUrl = "http://testing-ground.scraping.pro/login";
        driver.get(baseUrl);
    }


    @When("I enter the username")
    public void i_enter_the_username() {
        driver.findElement(By.id("usr")).sendKeys("admin");
    }

    @When("I enter the password")
    public void i_enter_the_password() {
        driver.findElement(By.id("pwd")).sendKeys("12345");
    }

    @When("I press enter")
    public void i_press_enter() {
        driver.findElement(By.id("pwd")).submit();
    }

    @Then("the text at the bottom of the page should say {string}")
    public void the_page_should_respond_with_text(String text) {
        List<WebElement> list = driver.findElements(By.xpath("//*[contains(text(),'" + text + "')]"));
        Assert.assertTrue("Text not found!", list.size() > 0);
    }


}
