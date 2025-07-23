pipeline {
    agent any
    stages {
        stage("BlackDuckSecruityScan") {
            when {
                // Triggering Black Duck Security Scan on master branch or Pull Request
                anyOf {
                    branch 'main'
                    branch pattern: "PR-\\d+", comparator: "REGEXP"
                }
            }
            steps {
                script {
                    def status = security_scan product: 'coverity',
                        // Uncomment if below parameters are not set in global configuration                  

                        coverity_stream_name: "multi-test", 
                        coverity_project_name: "multi-test",
                        coverity_waitForScan: false,
                        // Pull Request Comments
                          coverity_prComment_enabled: true,
                          
                        // Mark build status if issues found
                          mark_build_status: 'SUCCESS'
                
                    // Uncomment to add custom logic based on return status
                   //  if (status == 8) { unstable 'policy violation' }
                    // else if (status != 0) { error 'plugin failure' }
                }
            }
        }
    }
}          
