package runner;
import org.junit.runner.RunWith;


import io.cucumber.junit.Cucumber;
import io.cucumber.junit.CucumberOptions;
import io.cucumber.junit.CucumberOptions.*;

@RunWith(Cucumber.class)
@CucumberOptions(
    features = {"src/test/resources/features"},
    tags = "@GetCep",
    glue = "steps",
    monochrome = true,
    plugin = {"json:target/reports/CucumberReports.json", "pretty"},
    snippets = SnippetType.CAMELCASE    
)

public class RunnerTest {
    
}
